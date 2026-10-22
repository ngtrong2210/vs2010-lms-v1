<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InteractiveContentTest.aspx.cs" Inherits="InformationWeb.Pages.Cms.InteractiveContentTest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InteractiveContent Service Test</title>
    <style>
        body { font-family: Arial, sans-serif; padding: 20px; }
        .section { margin-bottom: 30px; padding: 15px; border: 1px solid #ccc; border-radius: 5px; }
        .section h2 { margin-top: 0; color: #333; }
        .button { padding: 8px 15px; margin-right: 10px; margin-bottom: 10px; cursor: pointer; }
        .success { color: green; font-weight: bold; }
        .error { color: red; font-weight: bold; }
        .result { margin-top: 10px; padding: 10px; background: #f5f5f5; border-radius: 3px; }
        .grid { margin-top: 10px; }
        .grid table { border-collapse: collapse; width: 100%; }
        .grid th, .grid td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        .grid th { background: #f0f0f0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>InteractiveContent Service Test</h1>
        <p>Pattern theo WEB_ARCHITECTURE_RULES.md (Pattern 1: Static Table với Caching + UI Helpers)</p>

        <!-- Test 1: Lấy danh sách Interactive Content -->
        <div class="section">
            <h2>1. GetInteractiveContentList</h2>
            <asp:Button ID="btnGetList" runat="server" Text="Lấy danh sách" CssClass="button" OnClick="btnGetList_Click" />
            <asp:Label ID="lblGetListResult" runat="server" CssClass="result"></asp:Label>
            <div class="grid">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>

        <!-- Test 2: Tạo Interactive Content mới -->
        <div class="section">
            <h2>2. CreateInteractiveContent</h2>
            <table>
                <tr>
                    <td>LessonID:</td>
                    <td><asp:TextBox ID="txtLessonId" runat="server" Width="200px" Text="1"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>CompletionRule:</td>
                    <td>
                        <asp:DropDownList ID="ddlCompletionRule" runat="server">
                            <asp:ListItem Value="ANSWER_ALL">ANSWER_ALL - Trả lời tất cả</asp:ListItem>
                            <asp:ListItem Value="PASSING_SCORE">PASSING_SCORE - Đạt điểm sàn</asp:ListItem>
                            <asp:ListItem Value="SPECIFIC_QUESTIONS">SPECIFIC_QUESTIONS - Câu hỏi cụ thể</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>RequireReading:</td>
                    <td><asp:CheckBox ID="chkRequireReading" runat="server" /></td>
                </tr>
                <tr>
                    <td>PassingScore (%):</td>
                    <td><asp:TextBox ID="txtPassingScore" runat="server" Width="100px" Text="70"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>ShowResultImmediately:</td>
                    <td><asp:CheckBox ID="chkShowResult" runat="server" Checked="true" /></td>
                </tr>
                <tr>
                    <td>ShowScore:</td>
                    <td><asp:CheckBox ID="chkShowScore" runat="server" Checked="true" /></td>
                </tr>
                <tr>
                    <td>CreatedByUserID:</td>
                    <td><asp:TextBox ID="txtCreatedByUserId" runat="server" Width="200px" Text="1"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnCreate" runat="server" Text="Tạo mới" CssClass="button" OnClick="btnCreate_Click" />
            <asp:Label ID="lblCreateResult" runat="server" CssClass="result"></asp:Label>
        </div>

        <!-- Test 3: Cập nhật Interactive Content -->
        <div class="section">
            <h2>3. UpdateInteractiveContent</h2>
            <table>
                <tr>
                    <td>InteractiveContentID:</td>
                    <td><asp:TextBox ID="txtUpdateId" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>CompletionRule:</td>
                    <td>
                        <asp:DropDownList ID="ddlUpdateCompletionRule" runat="server">
                            <asp:ListItem Value="ANSWER_ALL">ANSWER_ALL - Trả lời tất cả</asp:ListItem>
                            <asp:ListItem Value="PASSING_SCORE">PASSING_SCORE - Đạt điểm sàn</asp:ListItem>
                            <asp:ListItem Value="SPECIFIC_QUESTIONS">SPECIFIC_QUESTIONS - Câu hỏi cụ thể</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>RequireReading:</td>
                    <td><asp:CheckBox ID="chkUpdateRequireReading" runat="server" /></td>
                </tr>
                <tr>
                    <td>PassingScore (%):</td>
                    <td><asp:TextBox ID="txtUpdatePassingScore" runat="server" Width="100px" Text="80"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>ShowResultImmediately:</td>
                    <td><asp:CheckBox ID="chkUpdateShowResult" runat="server" Checked="true" /></td>
                </tr>
                <tr>
                    <td>ShowScore:</td>
                    <td><asp:CheckBox ID="chkUpdateShowScore" runat="server" Checked="true" /></td>
                </tr>
                <tr>
                    <td>UpdatedByUserID:</td>
                    <td><asp:TextBox ID="txtUpdatedByUserId" runat="server" Width="200px" Text="1"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="button" OnClick="btnUpdate_Click" />
            <asp:Label ID="lblUpdateResult" runat="server" CssClass="result"></asp:Label>
        </div>

        <!-- Test 4: Lấy theo Lesson ID -->
        <div class="section">
            <h2>4. GetByLessonId</h2>
            <asp:TextBox ID="txtLessonIdSearch" runat="server" Width="200px" Text="1"></asp:TextBox>
            <asp:Button ID="btnGetByLesson" runat="server" Text="Tìm theo LessonID" CssClass="button" OnClick="btnGetByLesson_Click" />
            <asp:Label ID="lblGetByLessonResult" runat="server" CssClass="result"></asp:Label>
            <div class="grid">
                <asp:GridView ID="gvByLesson" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>

        <!-- Test 5: Lấy theo ID -->
        <div class="section">
            <h2>5. GetById</h2>
            <asp:TextBox ID="txtIdSearch" runat="server" Width="200px"></asp:TextBox>
            <asp:Button ID="btnGetById" runat="server" Text="Tìm theo ID" CssClass="button" OnClick="btnGetById_Click" />
            <asp:Label ID="lblGetByIdResult" runat="server" CssClass="result"></asp:Label>
        </div>

        <!-- Test 6: Lấy câu hỏi -->
        <div class="section">
            <h2>6. GetQuestions</h2>
            <asp:TextBox ID="txtQuestionsId" runat="server" Width="200px"></asp:TextBox>
            <asp:Button ID="btnGetQuestions" runat="server" Text="Lấy câu hỏi" CssClass="button" OnClick="btnGetQuestions_Click" />
            <asp:Label ID="lblGetQuestionsResult" runat="server" CssClass="result"></asp:Label>
            <div class="grid">
                <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>

        <!-- Test 7: Xóa Interactive Content -->
        <div class="section">
            <h2>7. DeleteInteractiveContent</h2>
            <asp:TextBox ID="txtDeleteId" runat="server" Width="200px"></asp:TextBox>
            <asp:Button ID="btnDelete" runat="server" Text="Xóa" CssClass="button" OnClick="btnDelete_Click" />
            <asp:Label ID="lblDeleteResult" runat="server" CssClass="result"></asp:Label>
        </div>

        <!-- Test 8: UI Helper - InitDropDownList -->
        <div class="section">
            <h2>8. UI Helper - InitDropDownList</h2>
            <asp:Button ID="btnInitDDL" runat="server" Text="Khởi tạo DropDownList" CssClass="button" OnClick="btnInitDDL_Click" />
            <br /><br />
            <asp:DropDownList ID="ddlInteractiveContent" runat="server" Width="300px"></asp:DropDownList>
        </div>

        <!-- Test 9: Test Cache -->
        <div class="section">
            <h2>9. Test Cache (HaveNewData)</h2>
            <asp:Button ID="btnCheckCache" runat="server" Text="Kiểm tra cache" CssClass="button" OnClick="btnCheckCache_Click" />
            <asp:Button ID="btnRefreshCache" runat="server" Text="Làm mới cache" CssClass="button" OnClick="btnRefreshCache_Click" />
            <asp:Label ID="lblCacheResult" runat="server" CssClass="result"></asp:Label>
        </div>
    </form>
</body>
</html>
