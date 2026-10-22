<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Courses.ascx.cs" Inherits="InformationWeb.Controls.Lms.Courses" %>
<section>
    <header class="mb-5">
        <div class="section-title text-left">
            <div class="section-title__tagline-box"><span class="section-title__tagline">MÔN HỌC THEO LỚP</span></div>
            <h1 class="section-title__title"><asp:Literal ID="PageTitleText" runat="server" /></h1>
            <p class="mt-2"><asp:Literal ID="PageDescriptionText" runat="server" /></p>
        </div>
    </header>
    <asp:Label ID="ErrorText" runat="server" CssClass="alert alert-danger" Visible="false" />
    <div class="row">
        <aside class="col-xl-4 col-lg-5">
            <div class="course-grid__sidebar">
                <div class="course-grid__search course-grid__single">
                    <h3 class="mb-3">Tìm môn học</h3>
                    <p class="course-grid__search-text">Tìm nhanh theo tên môn học hoặc giảng viên.</p>
                    <div>
                        <asp:TextBox ID="CourseSearchText" runat="server" placeholder="Nhập từ khóa..." />
                        <asp:Button ID="CourseSearchButton" runat="server" Text="Tìm" OnClick="RefreshButton_Click" />
                    </div>
                </div>
                <div class="course-grid__price-filter course-grid__single">
                    <h3 class="mb-3">Trạng thái học tập</h3>
                    <div class="course-grid__price-filter-free-and-paid-course">
                        <label class="custom-radio">
                            <asp:DropDownList
                                ID="CourseStatusFilterList"
                                runat="server"
                                CssClass="form-select"
                                AutoPostBack="true"
                                OnSelectedIndexChanged="RefreshButton_Click"
                            >
                                <asp:ListItem Value="">Tất cả trạng thái</asp:ListItem>
                                <asp:ListItem Value="ENROLLED">Chưa bắt đầu</asp:ListItem>
                                <asp:ListItem Value="IN_PROGRESS">Đang học</asp:ListItem>
                                <asp:ListItem Value="COMPLETED">Hoàn thành</asp:ListItem>
                            </asp:DropDownList>
                        </label>
                        <asp:Button ID="RefreshButton" runat="server" Text="Áp dụng" CssClass="d-none" OnClick="RefreshButton_Click" />
                    </div>
                </div>
            </div>
        </aside>
        <div class="col-xl-8 col-lg-7">
            <div class="course-list__right">
                <div class="course-list__right-top">
                    <p class="course-list__right-top-text">
                        Hiển thị
                        <asp:Literal ID="CourseCountText" runat="server" />
                        môn học
                    </p>
                    <div class="course-list__right-top-btn">
                        <span><i class="bi bi-view-list"></i></span>
                    </div>
                </div>
                <asp:GridView ID="DataGrid" runat="server" CssClass="d-none" AutoGenerateColumns="true" />
                <asp:Label ID="EmptyText" runat="server" CssClass="text-center py-5" Text="Không có môn học phù hợp." Visible="false" />
                <asp:Repeater ID="CourseListRepeater" runat="server">
                    <ItemTemplate>
                        <article class="course-list__single">
                            <div class="course-list__img-box">
                                <div class="course-list__img"><img src='<%# CourseImage(Container.ItemIndex) %>' alt='<%# Eval("Title") %>' /></div>
                            </div>
                            <div class="course-list__content">
                                <div class="course-list__doller-and-heart">
                                    <div class="course-list__doller"><p><%# Eval("ProgressPercent") %>% hoàn thành</p></div>
                                    <div class="course-list__heart">
                                        <a href='<%# CourseUrl(Eval("Id"), Eval("ContinueLessonId")) %>'><i class="bi bi-bookmark"></i></a>
                                    </div>
                                </div>
                                <h2 class="course-list__title"><a href='<%# CourseUrl(Eval("Id"), Eval("ContinueLessonId")) %>'><%# Eval("Title") %></a></h2>
                                <div class="course-list__ratting-box">
                                    <div class="course-list__ratting">
                                        <span><i class="bi bi-star-fill"></i></span>
                                        <span><i class="bi bi-star-fill"></i></span>
                                        <span><i class="bi bi-star-fill"></i></span>
                                        <span><i class="bi bi-star-fill"></i></span>
                                        <span><i class="bi bi-star-fill"></i></span>
                                    </div>
                                    <p class="course-list__ratting-text"><%# Eval("CategoryName") %></p>
                                </div>
                                <ul class="course-list__meta list-unstyled">
                                    <li>
                                        <p>
                                            <span><i class="bi bi-bar-chart"></i></span>
                                            <%# EnrollmentStatusText(Eval("EnrollmentStatus")) %>
                                        </p>
                                    </li>
                                    <li>
                                        <p>
                                            <span><i class="bi bi-book"></i></span>
                                            <%# Eval("LessonCount") %> bài học
                                        </p>
                                    </li>
                                    <li>
                                        <p>
                                            <span><i class="bi bi-clock"></i></span>
                                            Học linh hoạt
                                        </p>
                                    </li>
                                </ul>
                                <div class="course-list__btn-and-client-info">
                                    <div class="course-list__btn-box">
                                        <a href='<%# CourseUrl(Eval("Id"), Eval("ContinueLessonId")) %>' class="thm-btn">
                                            Mở môn học
                                            <i class="bi bi-arrow-right"></i>
                                        </a>
                                    </div>
                                    <div class="course-list__client-box">
                                        <div class="course-list__client-img">
                                            <img src='<%# TeacherImage(Container.ItemIndex) %>' alt='<%# Eval("TeacherName") %>' />
                                        </div>
                                        <div class="course-list__client-content">
                                            <h4><%# Eval("TeacherName") %></h4>
                                            <p>Giảng viên</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</section>
