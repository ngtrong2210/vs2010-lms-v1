<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuizManagement.ascx.cs" Inherits="InformationWeb.Controls.Cms.QuizManagement" %>
<link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/css/pages/cms/quizmanagement.css") %>" />
<section class="quiz-management-container">
    <header class="quiz-management-header">
        <h1>Quản lý bài kiểm tra</h1>
        <p>Tạo và quản lý bài kiểm tra, đánh giá kiến thức của học viên.</p>
    </header>

    <asp:Label ID="ActionMessageText" runat="server" Visible="false" CssClass="quiz-alert" />

    <div class="quiz-filter-section">
        <div class="quiz-filter-row">
            <div class="quiz-filter-group">
                <label>Tìm kiếm</label>
                <asp:TextBox ID="SearchText" runat="server" CssClass="form-control" placeholder="Nhập từ khóa..." />
            </div>
            <div class="quiz-filter-group">
                <label>Khóa học</label>
                <asp:DropDownList ID="CourseFilter" runat="server" CssClass="form-control" />
            </div>
            <div class="quiz-filter-group">
                <label>Loại</label>
                <asp:DropDownList ID="TypeFilter" runat="server" CssClass="form-control">
                    <asp:ListItem Value="" Text="--Tất cả--" />
                    <asp:ListItem Value="LESSON" Text="Bài học" />
                    <asp:ListItem Value="CHAPTER" Text="Chương" />
                    <asp:ListItem Value="COURSE" Text="Khóa học" />
                </asp:DropDownList>
            </div>
            <div class="quiz-filter-actions">
                <asp:Button ID="FilterButton" runat="server" CssClass="btn btn-primary" Text="Lọc" OnClick="FilterButton_Click" />
                <asp:Button ID="ResetButton" runat="server" CssClass="btn btn-secondary" Text="Đặt lại" OnClick="ResetButton_Click" />
            </div>
        </div>
    </div>

    <div class="quiz-grid-section">
        <div class="quiz-grid-header">
            <h2>Danh sách bài kiểm tra</h2>
            <asp:Button ID="AddQuizButton" runat="server" CssClass="btn-add" Text="Thêm bài kiểm tra" OnClick="AddQuizButton_Click" />
        </div>
        <asp:GridView ID="QuizGrid" runat="server" AutoGenerateColumns="false"
            CssClass="quiz-grid" GridLines="None" AllowPaging="true" PageSize="20"
            OnRowCommand="QuizGrid_RowCommand" OnRowCreated="QuizGrid_RowCreated"
            OnPageIndexChanging="QuizGrid_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="QuizID" HeaderText="ID" HeaderStyle-Width="80" />
                <asp:BoundField DataField="Title" HeaderText="Tiêu đề" />
                <asp:BoundField DataField="CourseTitle" HeaderText="Khóa học" HeaderStyle-Width="150" />
                <asp:BoundField DataField="LessonTitle" HeaderText="Bài học" HeaderStyle-Width="150" />
                <asp:TemplateField HeaderText="Câu hỏi" HeaderStyle-Width="80">
                    <ItemTemplate>
                        <asp:Label ID="QuestionCountLabel" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DurationMinutes" HeaderText="Thời gian (phút)" HeaderStyle-Width="100" />
                <asp:BoundField DataField="PassingScore" HeaderText="Điểm qua" HeaderStyle-Width="80" />
                <asp:TemplateField HeaderText="Trạng thái" HeaderStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="StatusLabel" runat="server" CssClass="status-badge" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="180">
                    <ItemTemplate>
                        <div class="action-buttons">
                            <asp:Button ID="EditButton" runat="server" CommandName="EditQuiz"
                                CommandArgument='<%# Eval("QuizID") %>' CssClass="btn-action btn-edit"
                                Text="Sửa" />
                            <asp:Button ID="QuestionsButton" runat="server" CommandName="ManageQuestions"
                                CommandArgument='<%# Eval("QuizID") %>' CssClass="btn-action btn-questions"
                                Text="Câu hỏi" />
                            <asp:Button ID="DeleteButton" runat="server" CommandName="DeleteQuiz"
                                CommandArgument='<%# Eval("QuizID") %>' CssClass="btn-action btn-delete"
                                Text="Xóa" OnClientClick="return confirm('Bạn có chắc muốn xóa bài kiểm tra này?');" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="quiz-empty-state">
                    <div class="empty-icon">📝</div>
                    <div class="empty-title">Không có bài kiểm tra nào</div>
                    <div class="empty-message">Hãy thêm bài kiểm tra mới để bắt đầu.</div>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

    <asp:Panel ID="EditPanel" runat="server" CssClass="quiz-edit-panel" Visible="false">
        <h2>
            <asp:Literal ID="EditPanelTitle" runat="server" />
        </h2>
        <div class="quiz-form">
            <div class="quiz-form-group">
                <label>Tiêu đề <span class="required-mark">*</span></label>
                <asp:TextBox ID="TitleText" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="TitleRequired" runat="server" ControlToValidate="TitleText"
                    ErrorMessage="Vui lòng nhập tiêu đề" CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="quiz-form-group">
                <label>Mã</label>
                <asp:TextBox ID="CodeText" runat="server" CssClass="form-control" />
            </div>
            <div class="quiz-form-group">
                <label>Khóa học</label>
                <asp:DropDownList ID="CourseList" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="CourseList_SelectedIndexChanged" />
            </div>
            <div class="quiz-form-group">
                <label>Bài học</label>
                <asp:DropDownList ID="LessonList" runat="server" CssClass="form-control" />
            </div>
            <div class="quiz-form-group">
                <label>Loại</label>
                <asp:DropDownList ID="TypeList" runat="server" CssClass="form-control">
                    <asp:ListItem Value="LESSON" Text="Bài học" />
                    <asp:ListItem Value="CHAPTER" Text="Chương" />
                    <asp:ListItem Value="COURSE" Text="Khóa học" />
                </asp:DropDownList>
            </div>
            <div class="quiz-form-group">
                <label>Thời gian (phút)</label>
                <asp:TextBox ID="DurationText" runat="server" CssClass="form-control" TextMode="Number" Value="30" />
            </div>
            <div class="quiz-form-group">
                <label>Điểm qua (%)</label>
                <asp:TextBox ID="PassingScoreText" runat="server" CssClass="form-control" TextMode="Number" Value="60" />
            </div>
            <div class="quiz-form-group">
                <label>Thứ tự</label>
                <asp:TextBox ID="SortOrderText" runat="server" CssClass="form-control" TextMode="Number" Value="0" />
            </div>
            <div class="quiz-form-group full-width">
                <label>Mô tả</label>
                <asp:TextBox ID="DescriptionText" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>
            <div class="quiz-form-group full-width">
                <label>Hướng dẫn</label>
                <asp:TextBox ID="InstructionsText" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>
            <div class="quiz-form-actions">
                <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-primary" Text="Lưu" OnClick="SaveButton_Click" />
                <asp:Button ID="CancelButton" runat="server" CssClass="btn btn-secondary" Text="Hủy" OnClick="CancelButton_Click" />
            </div>
        </div>
        <asp:HiddenField ID="QuizIdValue" runat="server" />
    </asp:Panel>
</section>
