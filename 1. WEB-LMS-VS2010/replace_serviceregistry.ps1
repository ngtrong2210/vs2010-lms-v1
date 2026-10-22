# Script to replace ServiceRegistry with direct LmsObject calls
$basePath = "G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\1. WEB-LMS-VS2010\InformationWeb"

# List of files to update
$files = @(
    "Controls\Cms\CourseLibrary.ascx.cs",
    "Pages\Cms\InteractiveContentTest.aspx.cs",
    "Handlers\Lms\Module.ashx.cs",
    "Controls\Cms\Settings.ascx.cs",
    "Controls\Cms\CourseEnrollments.ascx.cs",
    "Controls\Lms\Results.ascx.cs",
    "Controls\Lms\LessonPlayer.ascx.cs",
    "Controls\Lms\Dashboard.ascx.cs",
    "Controls\Lms\Courses.ascx.cs",
    "Controls\Lms\Course.ascx.cs",
    "Controls\Cms\VideoLibrary.ascx.cs",
    "Controls\Cms\VideoEditor.ascx.cs",
    "Controls\Cms\Users.ascx.cs",
    "Controls\Cms\Search.ascx.cs",
    "Controls\Cms\Roles.ascx.cs",
    "Controls\Cms\Reports.ascx.cs",
    "Controls\Cms\Enrollments.ascx.cs",
    "Controls\Cms\Questions.ascx.cs",
    "Controls\Cms\Dashboard.ascx.cs",
    "Controls\Cms\Courses.ascx.cs",
    "Controls\Cms\ContentBuilder.ascx.cs",
    "Controls\Cms\AssignmentGrading.ascx.cs",
    "Controls\Cms\AcademicStructure.ascx.cs",
    "Controls\Auth\Login.ascx.cs",
    "MasterPages\Lms.Master.cs",
    "MasterPages\Cms.Master.cs",
    "Controls\Cms\Students.ascx.cs"
)

foreach ($file in $files) {
    $filePath = Join-Path $basePath $file
    if (Test-Path $filePath) {
        Write-Host "Processing: $file"
        $content = Get-Content $filePath -Raw -Encoding UTF8

        # Remove using LmsService; if present
        $content = $content -replace 'using LmsService;[^\r\n]*[\r\n]+', ''

        # Replace ServiceRegistry patterns
        $content = $content -replace 'ServiceRegistry\.Users\.GetDataSet\(([^)]+)\)', 'new SYS_Users().GetDataSet($1)'
        $content = $content -replace 'ServiceRegistry\.Users\.GetDataTable\(([^)]+)\)', 'new SYS_Users().GetDataTable($1)'
        $content = $content -replace 'ServiceRegistry\.Courses\.GetDataTable\(([^)]+)\)', 'new SIM_Courses().GetDataTable($1)'
        $content = $content -replace 'ServiceRegistry\.Courses\.GetDataSet\(([^)]+)\)', 'new SIM_Courses().GetDataSet($1)'
        $content = $content -replace 'ServiceRegistry\.Learning\.GetDataTable\(([^)]+)\)', 'new LMS_LearningSessions().GetDataTable($1)'
        $content = $content -replace 'ServiceRegistry\.Learning\.GetDataSet\(([^)]+)\)', 'new LMS_LearningSessions().GetDataSet($1)'
        $content = $content -replace 'ServiceRegistry\.Reports\.GetDataTable\(([^)]+)\)', 'new SIM_Report_Records().GetDataTable($1)'
        $content = $content -replace 'ServiceRegistry\.Reports\.GetDataSet\(([^)]+)\)', 'new SIM_Report_Records().GetDataSet($1)'
        $content = $content -replace 'ServiceRegistry\.Academic\.GetDataSet\(([^)]+)\)', 'new SIM_Class().GetDataSet($1)'
        $content = $content -replace 'ServiceRegistry\.Academic\.GetDataTable\(([^)]+)\)', 'new SIM_Class().GetDataTable($1)'
        $content = $content -replace 'ServiceRegistry\.InteractiveContent\.GetDataTable\(([^)]+)\)', 'new LMS_InteractiveContents().GetDataTable($1)'
        $content = $content -replace 'ServiceRegistry\.InteractiveContent\.GetDataSet\(([^)]+)\)', 'new LMS_InteractiveContents().GetDataSet($1)'
        $content = $content -replace 'ServiceRegistry\.Auth\.Login\(([^)]+)\)', 'new AuthService().Login($1)'
        $content = $content -replace 'ServiceRegistry\.Auth\.GetById\(([^)]+)\)', '(new SYS_Users() { ID = $1 }).Load() ? new SYS_Users() { ID = $1 } : null'

        # Add using LmsObject; if not present
        if ($content -notmatch 'using LmsObject;') {
            $content = $content -replace '(using System;)', '$1`r`nusing LmsObject;'
        }

        Set-Content $filePath $content -Encoding UTF8 -NoNewline
        Write-Host "  Updated: $file"
    } else {
        Write-Host "  NOT FOUND: $file"
    }
}

Write-Host "Done!"
