ALTER VIEW vw_submission_assignment_course_account
AS

SELECT a.[id]
      ,a.[canvas_id]
      ,a.[body]
      ,a.[url]
      ,a.[grade]
      ,a.[submitted_at]
      ,a.[submission_type]
      ,a.[workflow_state]
      ,a.[created_at]
      ,a.[updated_at]
      ,a.[processed]
      ,a.[process_attempts]
      ,a.[grade_matches_current_submission]
      ,a.[published_grade]
      ,a.[graded_at]
      ,a.[has_rubric_assessment]
      ,a.[attempt]
      ,a.[has_admin_comment]
      ,a.[assignment_id]
      ,a.[excused]
      ,a.[graded_anonymously]
      ,a.[grader_id]
      ,a.[group_id]
      ,a.[quiz_submission_id]
      ,a.[user_id]
      ,a.[grade_state]
      ,a.[posted_at]
      ,a.[ImportedSequence]
	  , us.name as 'user_name'
	  , course.id As course_id
	  , course.name As course_name
	  , acc.name As account_name
  FROM [CanvasDataDb].[dbo].[submission_dim] a
  INNER JOIN user_dim us ON us.id = a.user_id
  INNER JOIN assignment_dim assi ON assi.id = a.assignment_id
  INNER JOIN course_dim course ON course.id = assi.course_id
  INNER JOIN account_dim acc ON acc.id = course.account_id
  WHERE 2 = 2
