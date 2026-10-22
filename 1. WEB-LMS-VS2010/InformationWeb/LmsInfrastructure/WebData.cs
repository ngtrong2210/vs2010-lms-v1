using System;
using System.Data;
using System.Web.UI.WebControls;

namespace InformationWeb.LmsInfrastructure
{
    /// <summary>
    /// Lớp tiện ích cho các thao tác dữ liệu web.
    /// </summary>
    public static class WebData
    {
        /// <summary>
        /// Gán dữ liệu vào GridView và xử lý trạng thái hiển thị (dữ liệu rỗng, lỗi).
        /// </summary>
        /// <param name="grid">GridView cần gán dữ liệu.</param>
        /// <param name="table">DataTable chứa dữ liệu.</param>
        /// <param name="empty">Label hiển thị khi dữ liệu rỗng.</param>
        /// <param name="error">Label hiển thị khi có lỗi.</param>
        public static void Bind(GridView grid, DataTable table, Label empty, Label error)
        {
            if (grid == null) return;
            if (table == null)
            {
                grid.DataSource = null; grid.DataBind();
                if (empty != null) empty.Visible = false;
                if (error != null) { error.Text = "Không thể nạp dữ liệu từ store."; error.Visible = true; }
                return;
            }
            grid.DataSource = table;
            grid.DataBind();
            if (empty != null) empty.Visible = table.Rows.Count == 0;
            if (error != null) error.Visible = false;
        }

        /// <summary>
        /// Lấy giá trị chuỗi từ DataRow theo danh sách cột.
        /// </summary>
        /// <param name="row">DataRow chứa dữ liệu.</param>
        /// <param name="columns">Danh sách tên cột cần lấy (ưu tiên cột đầu tiên có giá trị).</param>
        /// <returns>Giá trị chuỗi hoặc rỗng nếu không tìm thấy.</returns>
        public static string Text(DataRow row, params string[] columns)
        {
            if (row == null || columns == null) return string.Empty;
            foreach (string column in columns)
                if (row.Table.Columns.Contains(column) && row[column] != DBNull.Value) return Convert.ToString(row[column]);
            return string.Empty;
        }

        /// <summary>
        /// Lấy giá trị số nguyên dài (long) từ DataRow theo danh sách cột.
        /// </summary>
        /// <param name="row">DataRow chứa dữ liệu.</param>
        /// <param name="columns">Danh sách tên cột cần lấy (ưu tiên cột đầu tiên có giá trị).</param>
        /// <returns>Giá trị long hoặc 0 nếu không chuyển đổi được.</returns>
        public static long Long(DataRow row, params string[] columns)
        {
            long value;
            return long.TryParse(Text(row, columns), out value) ? value : 0L;
        }

        /// <summary>
        /// Tạo DataTable rỗng với các cột được chỉ định.
        /// </summary>
        /// <param name="columns">Danh sách tên cột cần tạo.</param>
        /// <returns>DataTable rỗng với cấu trúc cột.</returns>
        public static DataTable EmptyTable(params string[] columns)
        {
            DataTable table = new DataTable();
            foreach (string column in columns) table.Columns.Add(column);
            return table;
        }
    }
}
