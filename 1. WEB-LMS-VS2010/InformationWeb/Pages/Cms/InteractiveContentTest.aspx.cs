using System;
using System.Data;
using System.Web.UI.WebControls;
using LmsObject;

namespace InformationWeb.Pages.Cms
{
    public partial class InteractiveContentTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Test automatic DDL init on page load
                // InteractiveContentService.InitDropDownList(ddlInteractiveContent);
            }
        }

        protected void btnGetList_Click(object sender, EventArgs e)
        {
            try
            {
                var interactiveContent = new LMS_InteractiveContents();
                DataTable dt = interactiveContent.GetDataTable("get_list");
                gvList.DataSource = dt;
                gvList.DataBind();
                lblGetListResult.Text = string.Format("<span class='success'>Success: Found {0} records</span>", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                lblGetListResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var values = new System.Collections.Generic.Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    { "@LessonID", long.Parse(txtLessonId.Text) },
                    { "@CompletionRule", ddlCompletionRule.SelectedValue },
                    { "@RequireReading", chkRequireReading.Checked },
                    { "@PassingScore", decimal.Parse(txtPassingScore.Text) },
                    { "@ShowResultImmediately", chkShowResult.Checked },
                    { "@ShowScore", chkShowScore.Checked },
                    { "@CreatedByUserID", long.Parse(txtCreatedByUserId.Text) }
                };

                var interactiveContent = new LMS_InteractiveContents();
                bool result = interactiveContent.ExecNonQuery("create", values);

                if (result)
                {
                    lblCreateResult.Text = "<span class='success'>Success: Interactive Content created successfully!</span>";
                    // Refresh list
                    btnGetList_Click(null, null);
                }
                else
                {
                    lblCreateResult.Text = "<span class='error'>Failed: Could not create Interactive Content</span>";
                }
            }
            catch (Exception ex)
            {
                lblCreateResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var values = new System.Collections.Generic.Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    { "@InteractiveContentID", long.Parse(txtUpdateId.Text) },
                    { "@CompletionRule", ddlUpdateCompletionRule.SelectedValue },
                    { "@RequireReading", chkUpdateRequireReading.Checked },
                    { "@PassingScore", decimal.Parse(txtUpdatePassingScore.Text) },
                    { "@ShowResultImmediately", chkUpdateShowResult.Checked },
                    { "@ShowScore", chkUpdateShowScore.Checked },
                    { "@UpdatedByUserID", long.Parse(txtUpdatedByUserId.Text) }
                };

                var interactiveContent = new LMS_InteractiveContents();
                bool result = interactiveContent.ExecNonQuery("update", values);

                if (result)
                {
                    lblUpdateResult.Text = "<span class='success'>Success: Interactive Content updated successfully!</span>";
                    // Refresh list
                    btnGetList_Click(null, null);
                }
                else
                {
                    lblUpdateResult.Text = "<span class='error'>Failed: Could not update Interactive Content (not found or error)</span>";
                }
            }
            catch (Exception ex)
            {
                lblUpdateResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnGetByLesson_Click(object sender, EventArgs e)
        {
            try
            {
                long lessonId = long.Parse(txtLessonIdSearch.Text);
                var values = new System.Collections.Generic.Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    { "@LessonID", lessonId }
                };
                var interactiveContent = new LMS_InteractiveContents();
                DataTable dt = interactiveContent.GetDataTable("get_by_lesson", values);
                gvByLesson.DataSource = dt;
                gvByLesson.DataBind();
                lblGetByLessonResult.Text = string.Format("<span class='success'>Success: Found {0} records for LessonID={1}</span>", dt.Rows.Count, lessonId);
            }
            catch (Exception ex)
            {
                lblGetByLessonResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnGetById_Click(object sender, EventArgs e)
        {
            try
            {
                long id = long.Parse(txtIdSearch.Text);
                var values = new System.Collections.Generic.Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    { "@InteractiveContentID", id }
                };
                var interactiveContent = new LMS_InteractiveContents();
                DataTable dt = interactiveContent.GetDataTable("get_by_id", values);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblGetByIdResult.Text = string.Format(
                        "<span class='success'>Success: Found - ID={0}, LessonID={1}, CompletionRule={2}, PassingScore={3}</span>",
                        row[LMS_InteractiveContents.C_InteractiveContentID],
                        row[LMS_InteractiveContents.C_LessonID],
                        row[LMS_InteractiveContents.C_CompletionRule],
                        row[LMS_InteractiveContents.C_PassingScore]);
                }
                else
                {
                    lblGetByIdResult.Text = "<span class='error'>Not found: Interactive Content does not exist</span>";
                }
            }
            catch (Exception ex)
            {
                lblGetByIdResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnGetQuestions_Click(object sender, EventArgs e)
        {
            try
            {
                long id = long.Parse(txtQuestionsId.Text);
                var values = new System.Collections.Generic.Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    { "@InteractiveContentID", id }
                };
                var interactiveContent = new LMS_InteractiveContents();
                DataTable dt = interactiveContent.GetDataTable("get_questions", values);
                gvQuestions.DataSource = dt;
                gvQuestions.DataBind();
                lblGetQuestionsResult.Text = string.Format("<span class='success'>Success: Found {0} questions</span>", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                lblGetQuestionsResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                long id = long.Parse(txtDeleteId.Text);
                var values = new System.Collections.Generic.Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                {
                    { "@InteractiveContentID", id }
                };
                var interactiveContent = new LMS_InteractiveContents();
                bool result = interactiveContent.ExecNonQuery("delete", values);
                if (result)
                {
                    lblDeleteResult.Text = "<span class='success'>Success: Interactive Content deleted successfully!</span>";
                    // Refresh list
                    btnGetList_Click(null, null);
                }
                else
                {
                    lblDeleteResult.Text = "<span class='error'>Failed: Could not delete Interactive Content</span>";
                }
            }
            catch (Exception ex)
            {
                lblDeleteResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnInitDDL_Click(object sender, EventArgs e)
        {
            try
            {
                InteractiveContentService.InitDropDownList(ddlInteractiveContent);
                lblGetListResult.Text = "<span class='success'>Success: DropDownList initialized</span>";
            }
            catch (Exception ex)
            {
                lblGetListResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnCheckCache_Click(object sender, EventArgs e)
        {
            try
            {
                bool haveNewData = InteractiveContentService.HaveNewData;
                DataTable table = InteractiveContentService.Table;
                lblCacheResult.Text = string.Format(
                    "<span class='success'>HaveNewData={0}, Table has {1} rows (cached)</span>",
                    haveNewData, table != null ? table.Rows.Count : 0);
            }
            catch (Exception ex)
            {
                lblCacheResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }

        protected void btnRefreshCache_Click(object sender, EventArgs e)
        {
            try
            {
                InteractiveContentService.HaveNewData = true;
                DataTable table = InteractiveContentService.Table;
                lblCacheResult.Text = string.Format(
                    "<span class='success'>Cache refreshed! Now HaveNewData={0}, Table has {1} rows</span>",
                    InteractiveContentService.HaveNewData, table != null ? table.Rows.Count : 0);
            }
            catch (Exception ex)
            {
                lblCacheResult.Text = string.Format("<span class='error'>Error: {0}</span>", ex.Message);
            }
        }
    }
}
