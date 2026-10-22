#!/usr/bin/env python3
"""
Script to extract all stored procedure names from C# files
"""
import os
import re
from collections import defaultdict

def extract_procedures_from_file(file_path):
    """Extract stored procedure names from a C# file"""
    procedures = set()

    try:
        with open(file_path, 'r', encoding='utf-8', errors='ignore') as f:
            content = f.read()

        # Pattern 1: GetDataTable("ProcedureName", ...)
        pattern1 = r'GetDataTable\s*\(\s*"([^"]+)"'
        matches1 = re.findall(pattern1, content)
        procedures.update(matches1)

        # Pattern 2: CreateNewStoredProcedure("ProcedureName")
        pattern2 = r'CreateNewStoredProcedure\s*\(\s*"([^"]+)"'
        matches2 = re.findall(pattern2, content)
        procedures.update(matches2)

        # Pattern 3: Procedure names in variables/assignments like "Procedure" = "..."
        pattern3 = r'"([A-Za-z_][A-Za-z0-9_]*)"'
        # This is too broad, skip for now

    except Exception as e:
        print(f"Error reading {file_path}: {e}")

    return procedures

def main():
    base_path = r"G:/0.DỰ ÁN/2.LMS-VS2010/WEB-LMS-VS2010/1. WEB-LMS-VS2010"

    all_procedures = defaultdict(list)

    # Walk through all C# files
    for root, dirs, files in os.walk(base_path):
        for file in files:
            if file.endswith('.cs'):
                file_path = os.path.join(root, file)
                procedures = extract_procedures_from_file(file_path)
                for proc in procedures:
                    all_procedures[proc].append(file_path)

    # Output results
    print("=" * 80)
    print("STORED PROCEDURES FOUND IN C# CODE")
    print("=" * 80)

    # Sort procedures alphabetically
    for proc in sorted(all_procedures.keys()):
        print(f"\n{proc}")
        for file_path in all_procedures[proc]:
            rel_path = file_path.replace(base_path, '')
            print(f"  - {rel_path}")

    # Generate SQL check script
    print("\n" + "=" * 80)
    print("SQL CHECK SCRIPT")
    print("=" * 80)
    print("\n-- Check all procedures found in code")
    for proc in sorted(all_procedures.keys()):
        print(f"SELECT '{proc}' AS ProcedureName,")
        print(f"    CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = '{proc}') THEN 'EXISTS' ELSE 'MISSING' END AS Status")
        print("UNION ALL")

    print("SELECT '' AS ProcedureName, '' AS Status; -- Remove this line")

if __name__ == "__main__":
    main()
