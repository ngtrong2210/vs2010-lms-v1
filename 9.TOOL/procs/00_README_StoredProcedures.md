# LMS Stored Procedures Documentation

## Overview
This directory contains all SQL Server stored procedures for the LMS (Learning Management System). The procedures are organized by functional module.

## Stored Procedures Index

### Course Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Course_Create` | Create a new course |
| `LMS_Course_Update` | Update course details |
| `LMS_Course_Delete` | Soft delete a course |
| `LMS_Course_GetList` | Get paginated list of courses with filters |
| `LMS_Course_GetDetails` | Get detailed information about a specific course |

### Lesson Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Lesson_Create` | Create a new lesson within a course |
| `LMS_Lesson_Update` | Update lesson details |
| `LMS_Lesson_Delete` | Soft delete a lesson |
| `LMS_Lesson_GetByCourse` | Get all lessons for a specific course |
| `LMS_Lesson_AttachVideo` | Attach a video to a lesson |
| `LMS_Lesson_TrackProgress` | Track student progress on a lesson |

### Content Management
| Procedure | Description |
|-----------|-------------|
| `LMS_ContentItem_Create` | Create a content item (text, document, etc.) |
| `LMS_ContentItem_Update` | Update content item details |
| `LMS_ContentItem_Delete` | Soft delete a content item |
| `LMS_Content_GetByLesson` | Get all content items for a lesson |
| `LMS_Content_TrackProgress` | Track content consumption progress |

### Enrollment Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Enrollment_EnrollStudent` | Enroll a student in a course |
| `LMS_Enrollment_GetByCourse` | Get all enrollments for a course (paginated) |
| `LMS_Enrollment_GetByStudent` | Get all courses a student is enrolled in |
| `LMS_Enrollment_Cancel` | Cancel an enrollment |

### Quiz Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Quiz_Create` | Create a new quiz |
| `LMS_Quiz_Update` | Update quiz details |
| `LMS_Quiz_Delete` | Soft delete a quiz |
| `LMS_Quiz_GetByLesson` | Get quiz details for a lesson |
| `LMS_Quiz_GetQuestions` | Get all questions for a quiz |
| `LMS_QuizQuestion_Create` | Create a quiz question |
| `LMS_QuizQuestion_Update` | Update a quiz question |
| `LMS_QuizQuestion_Delete` | Delete a quiz question |

### Quiz Attempts
| Procedure | Description |
|-----------|-------------|
| `LMS_QuizAttempt_Create` | Create a new quiz attempt |
| `LMS_QuizAttempt_SaveAnswer` | Save a single answer during a quiz attempt |
| `LMS_QuizAttempt_Submit` | Submit a completed quiz attempt |
| `LMS_QuizAttempt_GetDetails` | Get detailed results of a quiz attempt |
| `LMS_QuizAttempt_GetHistory` | Get all quiz attempts for a student |

### Survey Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Survey_SubmitResponse` | Submit a survey response |
| `LMS_SurveyAnswer_Create` | Create survey answer |

### Video Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Video_GetByLesson` | Get video attached to a lesson |
| `LMS_Video_DetachFromLesson` | Detach video from a lesson |
| `LMS_VideoLibrary_GetAvailable` | Get available video assets for teachers |
| `LMS_Video_GetUsageStats` | Get usage statistics for a video asset |

### Student Progress
| Procedure | Description |
|-----------|-------------|
| `LMS_Student_GetDashboardStats` | Get dashboard statistics for a student (active courses, progress, recent activity) |
| `LMS_Student_GetProgressSummary` | Get overall progress summary for a student |
| `LMS_Student_GetCourseProgress` | Get detailed progress for a specific course |

### Certificate Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Certificate_Generate` | Generate a certificate for completed course |
| `LMS_Certificate_GetByUser` | Get all certificates for a user |

### Discussion Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Discussion_Create` | Create a new discussion thread |
| `LMS_Discussion_Update` | Update a discussion |
| `LMS_Discussion_GetByCourse` | Get all discussions for a course |
| `LMS_Discussion_GetDetails` | Get discussion details with replies |

### Notification Management
| Procedure | Description |
|-----------|-------------|
| `LMS_Notification_GetForUser` | Get notifications for a user |
| `LMS_Notification_MarkAsRead` | Mark a specific notification as read |
| `LMS_Notification_MarkAllAsRead` | Mark all notifications as read |

### Analytics & Reporting
| Procedure | Description |
|-----------|-------------|
| `LMS_Admin_GetDashboardStats` | Get platform-wide dashboard statistics |
| `LMS_Teacher_GetDashboardStats` | Get teacher-specific dashboard statistics |
| `LMS_Teacher_GetCourseAnalytics` | Get detailed analytics for a specific course |

## Naming Convention
All stored procedures follow the naming pattern: `LMS_{Module}_{Action}`

## Common Parameters
- `@ActorId` - The ID of the user performing the action
- `@IsAdmin` - Bit flag indicating if the actor has admin privileges
- `@CreatedUser` / `@UpdatedUser` - Username for audit trail
- `@PageNumber` / `@PageSize` - Pagination parameters for list procedures

## Security Notes
- All procedures include authorization checks
- Admin bypass is available via `@IsAdmin = 1` parameter
- Teachers can only access their own courses and lessons
- Students can only access their own enrollments and progress
- Audit logs are created for all write operations

## Execution Notes
- All procedures use `SET NOCOUNT ON` for performance
- Transactional procedures use `SET XACT_ABORT ON`
- Errors are raised using `THROW` with custom error codes (50002-50099)
