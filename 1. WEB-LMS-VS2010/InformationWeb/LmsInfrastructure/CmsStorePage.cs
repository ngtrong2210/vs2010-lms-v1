using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using LmsObject;

namespace InformationWeb.LmsInfrastructure
{
    /// <summary>
    /// Lớp base cho các trang CMS sử dụng stored procedure để tải dữ liệu.
    /// </summary>
    public abstract class CmsStorePage : CmsPage
    {
        /// <summary>Literal hiển thị tiêu đề trang.</summary>
        protected Literal PageTitleText;
        /// <summary>Literal hiển thị mô tả trang.</summary>
        protected Literal PageDescriptionText;
        /// <summary>TextBox nhập từ khóa tìm kiếm.</summary>
        protected TextBox SearchText;
        /// <summary>GridView hiển thị dữ liệu.</summary>
        protected GridView DataGrid;
        /// <summary>Label hiển thị khi dữ liệu rỗng.</summary>
        protected Label EmptyText;
        /// <summary>Label hiển thị khi có lỗi.</summary>
        protected Label ErrorText;

        /// <summary>Tên stored procedure để lấy dữ liệu.</summary>
        protected abstract string Operation { get; }
        /// <summary>Tiêu đề của trang.</summary>
        protected abstract string PageTitle { get; }
        /// <summary>Mô tả của trang.</summary>
        protected virtual string PageDescription { get { return "Dữ liệu được nạp trực tiếp từ stored procedure của LMSCMS_DB_SAMPLE."; } }

        /// <summary>
        /// Xử lý sự kiện Load trang.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PageTitleText.Text = Server.HtmlEncode(PageTitle);
            PageDescriptionText.Text = Server.HtmlEncode(PageDescription);
            if (!IsPostBack) LoadData();
        }

        /// <summary>Xử lý sự kiện click nút tìm kiếm.</summary>
        protected void SearchButton_Click(object sender, EventArgs e) { LoadData(); }
        /// <summary>Xử lý sự kiện phân trang GridView.</summary>
        protected void DataGrid_PageIndexChanging(object sender, GridViewPageEventArgs e) { DataGrid.PageIndex = e.NewPageIndex; LoadData(); }

        /// <summary>
        /// Lấy danh sách tham số cho stored procedure.
        /// </summary>
        /// <returns>Dictionary chứa các tham số.</returns>
        protected virtual IDictionary<string, object> Parameters()
        {
            return new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tải dữ liệu từ stored procedure và hiển thị lên GridView.
        /// </summary>
        protected virtual void LoadData()
        {
            try
            {
                DataTable table = GetDataTable(Operation, Parameters());
                WebData.Bind(DataGrid, table, EmptyText, ErrorText);
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp trang " + PageTitle + " thất bại.", ex);
                WebData.Bind(DataGrid, null, EmptyText, ErrorText);
            }
        }

        /// <summary>
        /// Phương thức trừu tượng để lấy DataTable từ stored procedure.
        /// </summary>
        /// <param name="operation">Tên stored procedure.</param>
        /// <param name="parameters">Danh sách tham số.</param>
        /// <returns>DataTable chứa dữ liệu.</returns>
        protected abstract DataTable GetDataTable(string operation, IDictionary<string, object> parameters);

        /// <summary>
        /// Tạo Dictionary từ các cặp key-value được truyền vào.
        /// </summary>
        /// <param name="pairs">Các cặp key-value xen kẽ.</param>
        /// <returns>Dictionary chứa các tham số.</returns>
        protected IDictionary<string, object> Values(params object[] pairs)
        {
            Dictionary<string, object> values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i + 1 < pairs.Length; i += 2) values[Convert.ToString(pairs[i])] = pairs[i + 1];
            return values;
        }

        /// <summary>
        /// Hiển thị thông báo kết quả hành động.
        /// </summary>
        /// <param name="label">Label để hiển thị thông báo.</param>
        /// <param name="message">Nội dung thông báo.</param>
        /// <param name="success">True nếu thành công, False nếu thất bại.</param>
        protected void ShowActionResult(Label label, string message, bool success)
        {
            if (label == null) return;
            label.Text = Server.HtmlEncode(message);
            label.CssClass = "alert " + (success ? "alert-success" : "alert-danger") + " status-message";
            label.Visible = true;
        }
    }

    public abstract class CmsStoreControl : CmsControl
    {
        protected Literal PageTitleText;
        protected Literal PageDescriptionText;
        protected TextBox SearchText;
        protected GridView DataGrid;
        protected Label EmptyText;
        protected Label ErrorText;

        protected abstract string Operation { get; }
        protected abstract string PageTitle { get; }
        protected virtual string PageDescription { get { return "Dữ liệu được nạp trực tiếp từ stored procedure của LMSCMS_DB_SAMPLE."; } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PageTitleText.Text = Server.HtmlEncode(PageTitle);
            PageDescriptionText.Text = Server.HtmlEncode(PageDescription);
            if (!IsPostBack) LoadData();
        }

        protected void SearchButton_Click(object sender, EventArgs e) { LoadData(); }
        protected void DataGrid_PageIndexChanging(object sender, GridViewPageEventArgs e) { DataGrid.PageIndex = e.NewPageIndex; LoadData(); }
        protected virtual IDictionary<string, object> Parameters() { return new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase); }

        protected virtual void LoadData()
        {
            try { DataTable table = GetDataTable(Operation, Parameters()); WebData.Bind(DataGrid, table, EmptyText, ErrorText); }
            catch (Exception ex) { WebLog.Error("Nạp trang " + PageTitle + " thất bại.", ex); WebData.Bind(DataGrid, null, EmptyText, ErrorText); }
        }

        protected abstract DataTable GetDataTable(string operation, IDictionary<string, object> parameters);

        protected IDictionary<string, object> Values(params object[] pairs)
        {
            Dictionary<string, object> values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i + 1 < pairs.Length; i += 2) values[Convert.ToString(pairs[i])] = pairs[i + 1];
            return values;
        }

        /// <summary>
        /// Hiển thị thông báo kết quả hành động.
        /// </summary>
        /// <param name="label">Label để hiển thị thông báo.</param>
        /// <param name="message">Nội dung thông báo.</param>
        /// <param name="success">True nếu thành công, False nếu thất bại.</param>
        protected void ShowActionResult(Label label, string message, bool success)
        {
            if (label == null) return;
            label.Text = Server.HtmlEncode(message);
            label.CssClass = "alert " + (success ? "alert-success" : "alert-danger") + " status-message";
            label.Visible = true;
        }
    }
}
