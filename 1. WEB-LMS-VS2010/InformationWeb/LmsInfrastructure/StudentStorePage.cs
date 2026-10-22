using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using LmsObject;

namespace InformationWeb.LmsInfrastructure
{
    /// <summary>
    /// Lớp base cho các trang sinh viên sử dụng stored procedure để tải dữ liệu.
    /// </summary>
    public abstract class StudentStorePage : StudentPage
    {
        /// <summary>Literal hiển thị tiêu đề trang.</summary>
        protected Literal PageTitleText, PageDescriptionText;
        /// <summary>GridView hiển thị dữ liệu.</summary>
        protected GridView DataGrid;
        /// <summary>Label hiển thị khi dữ liệu rỗng hoặc có lỗi.</summary>
        protected Label EmptyText, ErrorText;
        /// <summary>Tên stored procedure để lấy dữ liệu.</summary>
        protected abstract string Operation { get; }
        /// <summary>Tiêu đề của trang.</summary>
        protected abstract string PageTitle { get; }
        /// <summary>Mô tả của trang.</summary>
        protected virtual string PageDescription { get { return "Dữ liệu học tập được cập nhật trực tiếp từ hệ thống."; } }
        /// <summary>Lấy danh sách tham số cho stored procedure.</summary>
        protected abstract IDictionary<string, object> Parameters();

        /// <summary>
        /// Xử lý sự kiện Load trang.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); PageTitleText.Text = Server.HtmlEncode(PageTitle); PageDescriptionText.Text = Server.HtmlEncode(PageDescription);
            if (!IsPostBack) LoadData();
        }
        /// <summary>Xử lý sự kiện click nút làm mới dữ liệu.</summary>
        protected void RefreshButton_Click(object sender, EventArgs e) { LoadData(); }

        /// <summary>
        /// Tải dữ liệu từ stored procedure và hiển thị lên GridView.
        /// </summary>
        protected virtual void LoadData()
        {
            try { DataTable table = GetDataTable(Operation, Parameters()); WebData.Bind(DataGrid, table, EmptyText, ErrorText); }
            catch (Exception ex) { WebLog.Error("Nạp " + PageTitle + " thất bại.", ex); WebData.Bind(DataGrid, null, EmptyText, ErrorText); }
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
        protected IDictionary<string, object> Values(params object[] pairs) { Dictionary<string, object> values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase); for (int i = 0; i + 1 < pairs.Length; i += 2) values[Convert.ToString(pairs[i])] = pairs[i + 1]; return values; }
    }

    /// <summary>
    /// Lớp base cho các UserControl sinh viên sử dụng stored procedure để tải dữ liệu.
    /// </summary>
    public abstract class StudentStoreControl : StudentControl
    {
        /// <summary>Literal hiển thị tiêu đề trang.</summary>
        protected Literal PageTitleText, PageDescriptionText;
        /// <summary>GridView hiển thị dữ liệu.</summary>
        protected GridView DataGrid;
        /// <summary>Label hiển thị khi dữ liệu rỗng hoặc có lỗi.</summary>
        protected Label EmptyText, ErrorText;
        /// <summary>Tên stored procedure để lấy dữ liệu.</summary>
        protected abstract string Operation { get; }
        /// <summary>Tiêu đề của trang.</summary>
        protected abstract string PageTitle { get; }
        /// <summary>Mô tả của trang.</summary>
        protected virtual string PageDescription { get { return "Dữ liệu học tập được cập nhật trực tiếp từ hệ thống."; } }
        /// <summary>Lấy danh sách tham số cho stored procedure.</summary>
        protected abstract IDictionary<string, object> Parameters();

        /// <summary>
        /// Xử lý sự kiện Load control.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); PageTitleText.Text = Server.HtmlEncode(PageTitle); PageDescriptionText.Text = Server.HtmlEncode(PageDescription);
            if (!IsPostBack) LoadData();
        }

        protected void RefreshButton_Click(object sender, EventArgs e) { LoadData(); }
        protected virtual void LoadData()
        {
            try { DataTable table = GetDataTable(Operation, Parameters()); WebData.Bind(DataGrid, table, EmptyText, ErrorText); }
            catch (Exception ex) { WebLog.Error("Nạp " + PageTitle + " thất bại.", ex); WebData.Bind(DataGrid, null, EmptyText, ErrorText); }
        }

        protected abstract DataTable GetDataTable(string operation, IDictionary<string, object> parameters);

        protected IDictionary<string, object> Values(params object[] pairs)
        {
            Dictionary<string, object> values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i + 1 < pairs.Length; i += 2) values[Convert.ToString(pairs[i])] = pairs[i + 1];
            return values;
        }
    }
}
