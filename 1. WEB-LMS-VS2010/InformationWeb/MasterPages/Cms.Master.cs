using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsObject;

namespace InformationWeb.MasterPages
{
    public partial class CmsMaster : MasterPage
    {
        protected Literal UserNameText,
            NotificationCountText;
        protected PlaceHolder AdminMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.Current == null)
                return;
            UserNameText.Text = Server.HtmlEncode(UserSession.Current.FullName);
            AdminMenu.Visible = UserSession.Current.IsAdmin;
            NotificationCountText.Text = UnreadCount(UserSession.Current.UserID).ToString();
        }

        private static int UnreadCount(long userId)
        {
            try
            {
                var notifications = new SYS_Notifications();
                DataSet data = notifications.GetDataSet(
                    "List",
                    Values("RecipientUserID", userId, "Limit", 5, "UnreadOnly", false)
                );
                return data != null && data.Tables.Count > 1 && data.Tables[1].Rows.Count > 0
                    ? Convert.ToInt32(data.Tables[1].Rows[0][0])
                    : 0;
            }
            catch (Exception ex)
            {
                WebLog.Error("Không thể nạp thông báo.", ex);
                return 0;
            }
        }

        private static System.Collections.Generic.IDictionary<string, object> Values(
            params object[] pairs
        )
        {
            System.Collections.Generic.Dictionary<string, object> values =
                new System.Collections.Generic.Dictionary<string, object>(
                    StringComparer.OrdinalIgnoreCase
                );
            for (int i = 0; i + 1 < pairs.Length; i += 2)
                values[Convert.ToString(pairs[i])] = pairs[i + 1];
            return values;
        }
    }
}
