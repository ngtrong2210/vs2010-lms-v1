param(
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$JobName,

    [string]$Root = (Get-Location).Path
)

$ErrorActionPreference = 'Stop'

if ($JobName.IndexOfAny([System.IO.Path]::GetInvalidFileNameChars()) -ge 0 -or
    $JobName -eq '.' -or $JobName -eq '..') {
    throw "JobName contains invalid path characters: $JobName"
}

$rootPath = [System.IO.Path]::GetFullPath($Root)
$jobPath = [System.IO.Path]::GetFullPath((Join-Path $rootPath $JobName))
$rootPrefix = $rootPath.TrimEnd([System.IO.Path]::DirectorySeparatorChar) + [System.IO.Path]::DirectorySeparatorChar

if (-not $jobPath.StartsWith($rootPrefix, [System.StringComparison]::OrdinalIgnoreCase)) {
    throw "Resolved job path is outside Root: $jobPath"
}
if (Test-Path -LiteralPath $jobPath) {
    throw "Job folder already exists: $jobPath"
}

[void](New-Item -ItemType Directory -Path $jobPath)
foreach ($folder in 'mau-chuan', 'can-sua', 'source', 'ket-qua') {
    [void](New-Item -ItemType Directory -Path (Join-Path $jobPath $folder))
}

$request = @'
MUC TIEU:
- Ghi ro can sua gi hoac can tao them mau nao.

MAU CHUAN:
- Ghi ten file trong thu muc mau-chuan va phan nao can lay lam chuan.

FILE CAN SUA/TAO:
- Ghi quy tac ten file, khoang so mon/bien the/quy che neu biet.

YEU CAU GIU NGUYEN:
- Ghi cac phan khong duoc thay doi (bo cuc, script, le trang, footer...).

GHI CHU KIEM TRA:
- Ghi du lieu dac biet can hien thi, vi du -1 phai thanh M.
'@

[System.IO.File]::WriteAllText(
    (Join-Path $jobPath 'yeu-cau.txt'),
    $request,
    [System.Text.UTF8Encoding]::new($false)
)

$jobPath
