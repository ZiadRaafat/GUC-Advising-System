--DROP DATABASE Advising_Team_47

CREATE DATABASE Advising_System

GO
USE Advising_System

GO 
CREATE PROCEDURE CreateAllTables AS

CREATE TABLE Advisor(
advisor_id int PRIMARY KEY IDENTITY,
name varchar(40) NOT NULL,
email varchar(40) NOT NULL,
office varchar(40) NOT NULL,
password varchar(40) NOT NULL
);

CREATE TABLE Student(
student_id int PRIMARY KEY IDENTITY,
f_name varchar(40) NOT NULL,
l_name varchar(40) NOT NULL,
gpa decimal(10,2) check(gpa BETWEEN 0.7 AND 5), 
faculty varchar(40) NOT NULL,
email varchar(40) NOT NULL,
major varchar(40) NOT NULL,
password varchar(40) NOT NULL,
financial_status bit, --have a function to derive it
semester int NOT NULL,
acquired_hours int,  
assigned_hours int,
advisor_id int ,
CONSTRAINT FK_Student FOREIGN KEY(advisor_id) references Advisor(advisor_id) 
);

CREATE TABLE Course(
course_id int PRIMARY KEY IDENTITY,  --identity to be compatible with procedure
name varchar(40) NOT NULL,
major varchar(40) NOT NULL,
is_offered bit NOT NULL,
credit_hours int NOT NULL,
semester int NOT NULL
);

CREATE TABLE Request(
request_id int primary key IDENTITY,
type varchar(40) not null,
comment varchar(40) not null,
status varchar(40) not null check(status IN ('pending','approved','rejected')) default 'pending',
credit_hours int,  
student_id int not null,
advisor_id int not null,
course_id int,
CONSTRAINT FK_Request_S foreign key (student_id) references Student(student_id),
CONSTRAINT FK_Request_A foreign key (advisor_id) references Advisor(advisor_id),
CONSTRAINT FK_Request_C foreign key (course_id) references Course(course_id)
);

CREATE TABLE Semester(
semester_code varchar(40) PRIMARY KEY,
start_date DATE NOT NULL, 
end_date DATE NOT NULL);

CREATE TABLE Payment(
payment_id int primary key IDENTITY,
amount int not null,
deadline datetime not null,
n_installments int not null ,
status varchar(40) not null default 'notPaid' check (status in ('notPaid','Paid')),
fund_percentage decimal(10,2) not null, --important: max=100.00
start_date datetime not null,
student_id int not null,
semester_code varchar(40) not null,
CONSTRAINT FK_Payment_S foreign key (student_id) references Student(student_id) ,
CONSTRAINT FK_Payment_SC foreign key (semester_code) references Semester(semester_code)
);

CREATE TABLE Installment(
payment_id int ,
deadline datetime,
amount int not null,
status varchar(40) default 'notPaid' check (status in ('notPaid','Paid')), 
start_date datetime not null,
CONSTRAINT FK_Installment foreign key (payment_id) references Payment(payment_id) ,
primary key(payment_id,deadline)
);

CREATE TABLE Student_Phone(
student_id int ,
phone_number varchar(40), 
PRIMARY KEY(student_id,phone_number),
CONSTRAINT FK_SP FOREIGN KEY(student_id) references Student(student_id)
);

CREATE TABLE Instructor(
instructor_id int PRIMARY KEY IDENTITY,
name varchar(40) NOT NULL,
email varchar(40) NOT NULL,
faculty varchar(40) NOT NULL,
office varchar(40) NOT NULL
);

CREATE TABLE PreqCourse_course(
prerequisite_course_id int NOT NULL,
course_id int NOT NULL,
PRIMARY KEY(prerequisite_course_id, course_id),
CONSTRAINT FK_Preq FOREIGN KEY(prerequisite_course_id) references Course(course_id),
CONSTRAINT FK_PreqC FOREIGN KEY(course_id) references Course(course_id)
);

CREATE TABLE Instructor_Course(
course_id int NOT NULL,
instructor_id int NOT NULL,
PRIMARY KEY(course_id,instructor_id),
CONSTRAINT FK_ICC FOREIGN KEY(course_id) references Course(course_id),
CONSTRAINT FK_ICI FOREIGN KEY(instructor_id) references Instructor(instructor_id)
);

CREATE TABLE Student_Instructor_Course_Take(
student_id int,
course_id int ,
instructor_id int,
semester_code varchar(40),
exam_type varchar(40) DEFAULT 'Normal',
grade varchar(40),  
PRIMARY KEY(student_id,course_id,semester_code),
CONSTRAINT FK_SIC1 FOREIGN KEY(student_id) references Student(student_id),
CONSTRAINT FK_SIC2 FOREIGN KEY(course_id) references Course(course_id),
CONSTRAINT FK_SIC3 FOREIGN KEY(instructor_id) references Instructor(instructor_id)
);

CREATE TABLE MakeUp_Exam(
exam_id int PRIMARY KEY IDENTITY,
date datetime NOT NULL,
type varchar(40) NOT NULL,
course_id int not null,
CONSTRAINT FK_MU FOREIGN KEY (course_id) references Course(course_id)
);

CREATE TABLE Exam_Student(
exam_id int not null,
student_id int not null,
course_id int NOT NULL,
PRIMARY KEY(exam_id, student_id),
CONSTRAINT FK_ES1 FOREIGN KEY (exam_id) references MakeUp_Exam(exam_id),
CONSTRAINT FK_ES2 FOREIGN KEY (student_id) references Student(student_id)
);

CREATE TABLE Graduation_Plan(
plan_id int IDENTITY, 
semester_code varchar(40) , 
semester_credit_hours int NOT NULL, 
expected_grad_date DATE NOT NULL , 
advisor_id int NOT NULL ,
student_id int NOT NULL,
CONSTRAINT FK_GP1 FOREIGN KEY(advisor_id) references Advisor(advisor_id),
CONSTRAINT FK_GP2 FOREIGN KEY(student_id) references Student(student_id),
primary key(plan_id,semester_code)
);

CREATE TABLE GradPlan_Course(
plan_id int ,
semester_code varchar(40) , 
course_id int,
CONSTRAINT FK_GC1 FOREIGN KEY(plan_id, semester_code) references Graduation_Plan(plan_id, semester_code),
primary key(plan_id,semester_code,course_id)
);

CREATE TABLE Slot(
slot_id int PRIMARY KEY IDENTITY, 
day varchar(40) NOT NULL, 
time varchar(40) NOT NULL , 
location varchar(40) NOT NULL, 
course_id int,
instructor_id int,
CONSTRAINT FK_SC1 FOREIGN KEY (course_id) references Course(course_id) , 
CONSTRAINT FK_SC2 FOREIGN KEY (instructor_id) references Instructor(instructor_id) 
);

CREATE TABLE Course_Semester(
course_id int , 
semester_code varchar(40) ,
CONSTRAINT FK_CS1 FOREIGN KEY(course_id) references Course(course_id) , 
CONSTRAINT FK_CS2 FOREIGN KEY(semester_code) references Semester(semester_code),
primary key(semester_code, course_id)
);
GO

EXEC CreateAllTables;

-- ***STUDENT FINANCIAL STATUS COLUMN
GO
CREATE FUNCTION dbo.getFinancialStatus 
(@student_id int)
returns bit
AS BEGIN
declare @output bit
If EXISTS(Select * FROM Student S INNER JOIN Payment P ON S.student_id=P.student_id 
INNER JOIN Installment I ON I.payment_id=P.payment_id WHERE S.student_id=@student_id AND I.deadline<CURRENT_TIMESTAMP AND I.status='notPaid')
SET @output=0
ELSE 
SET @output=1
return @output end
GO

/**
SELECT * FROM INSTALLMENT;
SELECT * FROM PAYMENT;
SELECT * FROM STUDENT;
UPDATE Student SET financial_status=dbo.getFinancialStatus(student_id)
INSERT INTO Installment (payment_id, start_date, amount, status, deadline) VALUES
(1, '2023-11-22', 50, 'notPaid','2023-3-22');
**/

----------------------------------- TEST VALUES ---------------------------------------

INSERT INTO Advisor VALUES('ahmed','hi@gmail.com','C5','cheese');
INSERT INTO Student VALUES('ali','z',2.1,'eng','@','MET','batetes',1,4,3,2,1);
INSERT INTO Course VALUES('math','eng',1,23,1);
INSERT INTO Request VALUES('course_request','hi','pending',13,1,1,1);
INSERT INTO Semester VALUES('1','1-11-2000','1-12-2000');
INSERT INTO Payment VALUES(12345,'11-25-2000',4,'notPaid',50,'7-2-2000',1,'1');
INSERT INTO Installment VALUES(49,'11-2-2000',13,'notPaid','11-20-2000');
INSERT INTO Instructor VALUES('ah','@','M','C');
INSERT INTO MakeUp_Exam VALUES('11-2-2020','First_makeup',1);
INSERT INTO Graduation_Plan VALUES('s23',20,'11-20-2024',1,1);
INSERT INTO Slot VALUES('mon','first','C3.215',1,1);


SELECT * FROM Semester
----------------------------------------------------------------------------------------

GO
CREATE PROCEDURE DropAllTables AS
ALTER TABLE Student
DROP Constraint FK_Student;
ALTER TABLE Request
DROP CONSTRAINT FK_Request_S, FK_Request_A, FK_Request_C;
ALTER TABLE Payment
DROP CONSTRAINT FK_Payment_S,FK_Payment_SC;
ALTER TABLE Installment
DROP CONSTRAINT FK_Installment;
ALTER TABLE Student_Phone
DROP CONSTRAINT FK_SP;
ALTER TABLE PreqCourse_course
DROP CONSTRAINT FK_Preq,FK_PreqC;
ALTER TABLE Instructor_Course
DROP CONSTRAINT FK_ICC,FK_ICI;
ALTER TABLE Student_Instructor_Course_Take
DROP CONSTRAINT FK_SIC1,FK_SIC2,FK_SIC3;
ALTER TABLE GradPlan_Course
DROP CONSTRAINT FK_GC1;
ALTER TABLE Graduation_Plan
DROP CONSTRAINT FK_GP1,FK_GP2;
ALTER TABLE Slot
DROP CONSTRAINT FK_SC1,FK_SC2;
ALTER TABLE Course_Semester
DROP CONSTRAINT FK_CS1,FK_CS2;
ALTER TABLE Exam_Student
DROP CONSTRAINT FK_ES1,FK_ES2;
ALTER TABLE MakeUp_Exam
DROP CONSTRAINT FK_MU;

DROP TABLE Advisor;
DROP TABLE Student_Phone;
DROP TABLE Request;
DROP TABLE Semester;
DROP TABLE Payment;
DROP TABLE Installment;
DROP TABLE Instructor;
DROP TABLE PreqCourse_course;
DROP TABLE Instructor_Course;
DROP TABLE Student_Instructor_Course_Take;
DROP TABLE Exam_Student;
DROP TABLE Graduation_Plan;
DROP TABLE GradPlan_Course;
DROP TABLE Slot;
DROP TABLE Course_Semester;
DROP TABLE Student;
DROP TABLE MakeUp_Exam;
DROP TABLE Course;
GO 
--DROP PROC DropAllTables
--EXEC DropAllTables

GO
CREATE PROCEDURE clearAllTables AS
ALTER TABLE Student
DROP Constraint FK_Student;
ALTER TABLE Request
DROP CONSTRAINT FK_Request_S, FK_Request_A, FK_Request_C;
ALTER TABLE Payment
DROP CONSTRAINT FK_Payment_S,FK_Payment_SC;
ALTER TABLE Installment
DROP CONSTRAINT FK_Installment;
ALTER TABLE Student_Phone
DROP CONSTRAINT FK_SP;
ALTER TABLE PreqCourse_course
DROP CONSTRAINT FK_Preq,FK_PreqC;
ALTER TABLE Instructor_Course
DROP CONSTRAINT FK_ICC,FK_ICI;
ALTER TABLE Student_Instructor_Course_Take
DROP CONSTRAINT FK_SIC1,FK_SIC2,FK_SIC3;
ALTER TABLE GradPlan_Course
DROP CONSTRAINT FK_GC1;
ALTER TABLE Graduation_Plan
DROP CONSTRAINT FK_GP1,FK_GP2;
ALTER TABLE Slot
DROP CONSTRAINT FK_SC1,FK_SC2;
ALTER TABLE Course_Semester
DROP CONSTRAINT FK_CS1,FK_CS2;
ALTER TABLE Exam_Student
DROP CONSTRAINT FK_ES1,FK_ES2;
ALTER TABLE MakeUp_Exam
DROP CONSTRAINT FK_MU;

TRUNCATE TABLE Course_Semester;
TRUNCATE TABLE Slot;
TRUNCATE TABLE GradPlan_Course;
TRUNCATE TABLE Student_Phone;
TRUNCATE TABLE Student;
TRUNCATE TABLE Graduation_Plan;
TRUNCATE TABLE Exam_Student;
TRUNCATE TABLE MakeUp_Exam;
TRUNCATE TABLE Student_Instructor_Course_Take;
TRUNCATE TABLE Instructor_Course;
TRUNCATE TABLE PreqCourse_course;
TRUNCATE TABLE Instructor;
TRUNCATE TABLE Installment;
TRUNCATE TABLE Payment;
TRUNCATE TABLE Semester;
TRUNCATE TABLE Request;
TRUNCATE TABLE Course;
TRUNCATE TABLE Advisor;

ALTER TABLE Student
ADD CONSTRAINT FK_Student FOREIGN KEY(advisor_id) references Advisor(advisor_id);

ALTER TABLE Request
ADD CONSTRAINT  FK_Request_S foreign key (student_id) references Student(student_id),
CONSTRAINT FK_Request_A foreign key (advisor_id) references Advisor(advisor_id),
CONSTRAINT FK_Request_C foreign key (course_id) references Course(course_id);

ALTER TABLE Payment
ADD CONSTRAINT  FK_Payment_S foreign key (student_id) references Student(student_id) ,
CONSTRAINT FK_Payment_SC foreign key (semester_code) references Semester(semester_code);

ALTER TABLE Installment 
ADD CONSTRAINT FK_Installment foreign key (payment_id) references Payment(payment_id);

ALTER TABLE Student_Phone
ADD CONSTRAINT FK_SP FOREIGN KEY(student_id) references Student(student_id);

ALTER TABLE PreqCourse_course
ADD CONSTRAINT FK_Preq FOREIGN KEY(prerequisite_course_id) references Course(course_id),
CONSTRAINT FK_PreqC FOREIGN KEY(course_id) references Course(course_id);

ALTER TABLE Instructor_Course
ADD CONSTRAINT FK_ICC FOREIGN KEY(course_id) references Course(course_id),
CONSTRAINT FK_ICI FOREIGN KEY(instructor_id) references Instructor(instructor_id);

ALTER TABLE Student_Instructor_Course_Take
ADD CONSTRAINT FK_SIC1 FOREIGN KEY(student_id) references Student(student_id),
CONSTRAINT FK_SIC2 FOREIGN KEY(course_id) references Course(course_id),
CONSTRAINT FK_SIC3 FOREIGN KEY(instructor_id) references Instructor(instructor_id);

ALTER TABLE GradPlan_Course
ADD CONSTRAINT FK_GC1 FOREIGN KEY(plan_id, semester_code) references Graduation_Plan(plan_id, semester_code);

ALTER TABLE Graduation_Plan
ADD CONSTRAINT FK_GP1 FOREIGN KEY(advisor_id) references Advisor(advisor_id),
CONSTRAINT FK_GP2 FOREIGN KEY(student_id) references Student(student_id);

ALTER TABLE Slot
ADD CONSTRAINT FK_SC1 FOREIGN KEY (course_id) references Course(course_id) , 
CONSTRAINT FK_SC2 FOREIGN KEY (instructor_id) references Instructor(instructor_id);

ALTER TABLE Course_Semester
ADD CONSTRAINT FK_CS1 FOREIGN KEY(course_id) references Course(course_id) , 
CONSTRAINT FK_CS2 FOREIGN KEY(semester_code) references Semester(semester_code);

ALTER TABLE Exam_Student
ADD CONSTRAINT FK_ES1 FOREIGN KEY (exam_id) references MakeUp_Exam(exam_id),
CONSTRAINT FK_ES2 FOREIGN KEY (student_id) references Student(student_id);

ALTER TABLE MakeUp_Exam
ADD CONSTRAINT FK_MU FOREIGN KEY (course_id) references Course(course_id);
GO
--DROP PROC clearAllTables
--EXEC clearAllTables

-- ***STUDENT FINANCIAL STATUS COLUMN
GO
CREATE FUNCTION dbo.calculateFinancialStatus 
(@student_id int)
returns bit
AS BEGIN
declare @output bit
If EXISTS(Select * FROM Student S INNER JOIN Payment P ON S.student_id=P.student_id 
INNER JOIN Installment I ON I.payment_id=P.payment_id WHERE S.student_id=@student_id AND I.deadline<CURRENT_TIMESTAMP AND I.status='notPaid')
SET @output=0
ELSE 
SET @output=1
return @output end
GO


UPDATE Student SET financial_status=dbo.calculateFinancialStatus(student_id)
INSERT INTO Installment (payment_id, start_date, amount, status, deadline) VALUES
(1, '2023-11-22', 50, 'notPaid','2023-3-22');
go

--******************  Basic Data Retrieval  *****************

---------------------------A----------------------------------
go
CREATE VIEW view_Students AS
SELECT student_id, f_name, l_name, gpa, 
faculty, email, major, password, semester, acquired_hours, assigned_hours int,
advisor_id FROM Student WHERE financial_status=1;
go

SELECT * FROM view_Students;
---------------------------B----------------------------------

GO
CREATE VIEW view_Course_prerequisites AS
SELECT C.*,PC.prerequisite_course_id ,C2.name prerequisite_name
FROM Course C LEFT OUTER JOIN 
     PreqCourse_course PC ON C.course_id=PC.course_id 
     LEFT OUTER JOIN Course C2 ON PC.course_id=C2.course_id;
     go
 SELECT * FROM view_Course_prerequisites;
 ---------------------------C----------------------------------

GO 
CREATE VIEW Instructors_AssignedCourses AS
SELECT I.*,C.name AS 'course_name'     --? do we include ID too?
FROM Instructor I INNER JOIN 
     Instructor_Course IC ON I.instructor_id=IC.instructor_id INNER JOIN
     Course C ON IC.course_id=C.course_id;
     go
 SELECT * FROM Instructors_AssignedCourses;
 ---------------------------D----------------------------------

GO
CREATE VIEW Student_Payment AS
SELECT S.f_name,S.l_name ,P.*  --? get student's full name plus ID?
FROM Payment P INNER JOIN 
     Student S ON P.student_id=S.student_id;
     go
 SELECT * FROM Student_Payment;
 ---------------------------E----------------------------------

GO 
CREATE VIEW Courses_Slots_Instructor AS
SELECT C.course_id,C.name AS 'course_name',S.slot_id, S.day,S.time,S.location,I.name AS 'instructor_name'
FROM Course C LEFT OUTER JOIN 
     Instructor_Course IC ON C.course_id=IC.course_id LEFT OUTER JOIN
     Slot S ON S.course_id=C.course_id AND S.instructor_id=IC.instructor_id LEFT OUTER JOIN
     Instructor I ON I.instructor_id=IC.instructor_id;
     go
SELECT * FROM Courses_Slots_Instructor;
---------------------------F----------------------------------

GO
CREATE VIEW Courses_MakeupExams AS
SELECT C.name,C.semester, M.exam_id,M.date,M.type
FROM Course C LEFT OUTER JOIN 
     MakeUp_Exam M ON C.course_id=M.course_id;
     go
SELECT * FROM Courses_MakeupExams;     
---------------------------G----------------------------------

GO 
CREATE VIEW Students_Courses_transcript AS  --? semester student took in the code format not numeric?
SELECT S.student_id,S.f_name,S.l_name,C.course_id,C.name AS 'course_name',T.exam_type,T.grade,T.semester_code,I.name AS 'instructor_name'
FROM Student_Instructor_Course_Take T INNER JOIN
     STUDENT S ON S.student_id=T.student_id INNER JOIN
     Instructor I ON I.instructor_id=T.instructor_id INNER JOIN
     Course C ON T.course_id=C.course_id;
     go
SELECT * FROM Students_Courses_transcript; 
---------------------------H----------------------------------

GO 
CREATE VIEW Semester_offered_Courses AS
SELECT C.course_id,C.name,S.semester_code
FROM Semester S LEFT OUTER JOIN
     Course_Semester CS ON S.semester_code=CS.semester_code LEFT OUTER JOIN
     Course C ON C.course_id=CS.course_id;
     go
 SELECT * FROM Semester_offered_Courses; 
 ---------------------------I----------------------------------

GO 
CREATE VIEW Advisors_Graduation_Plan AS
SELECT G.plan_id,G.semester_code,G.semester_credit_hours,G.expected_grad_date,
G.student_id,G.advisor_id,A.name as 'advisor_name'
FROM Graduation_Plan G INNER JOIN
     Advisor A ON G.advisor_id=A.advisor_id;
     go
 SELECT * FROM Advisors_Graduation_Plan; 

--******************  All Other Requirements  *****************
--Drop Proc 
---------------------------A----------------------------------

GO
CREATE PROC Procedures_StudentRegistration
@first_name varchar(40),
@last_name varchar(40),
@password varchar(40),
@faculty varchar(40),
@email varchar(40),
@major varchar(40),
@semester int,
@studentID int OUTPUT
AS
INSERT INTO Student(f_name, l_name, password, faculty, email, major, semester)  --?shouldn't student be registered with GPA and acq hours?
VALUES(@first_name, @last_name, @password, @faculty, @email, @major, @semester);  
SELECT @studentID=student_id FROM Student
WHERE email=@email;;
GO

declare @ID int;
EXEC Procedures_StudentRegistration 'ahmed','sameh','frewr','eng','@mail','CSEN MET', 5, @ID OUTPUT;   
print(@ID);

select * from Student
---------------------------B----------------------------------


GO
CREATE PROC Procedures_AdvisorRegistration
@name varchar(40),
@password varchar(40),
@email varchar(40),
@office varchar (40),
@advisorID int OUTPUT
AS
INSERT INTO Advisor VALUES(@name, @email, @office, @password); 
SELECT @advisorID=advisor_id FROM Advisor
WHERE email=@email AND name=@name;;
GO


declare @ID int;
EXEC Procedures_AdvisorRegistration 'heba', 'rq2f','2mail','C4.123',@ID OUTPUT ;
print @ID;

---------------------------C----------------------------------

GO
CREATE PROC Procedures_AdminListStudents
AS
SELECT student_id,f_name,l_name FROM Student;;  --? intended info to be displayed?
GO  
EXEC Procedures_AdminListStudents
---------------------------D----------------------------------

GO
CREATE PROC Procedures_AdminListAdvisors
AS
SELECT advisor_id,name FROM Advisor;;
GO
EXEC Procedures_AdminListAdvisors
---------------------------E----------------------------------

GO
CREATE PROC AdminListStudentsWithAdvisors
AS
SELECT S.student_id,S.f_name,S.l_name,A.advisor_id, A.name AS 'advisor_name' 
FROM Student S,Advisor A
WHERE S.advisor_id=A.advisor_id;;
GO
EXEC AdminListStudentsWithAdvisors
---------------------------F----------------------------------

GO
CREATE PROC AdminAddingSemester
@start_date date,
@end_date date,
@semester_code varchar(40)
AS
INSERT INTO Semester VALUES(@semester_code, @start_date, @end_date);;
GO 
EXEC AdminAddingSemester '10-1-2020','12-1-2020','W20'
---------------------------G----------------------------------

GO
CREATE PROC Procedures_AdminAddingCourse
@major varchar(40), 
@semester int,
@credit_hours int,
@course_name varchar(40), 
@offered bit
AS 
INSERT INTO Course VALUES(@course_name, @major, @offered, @credit_hours, @semester);;
GO
EXEC Procedures_AdminAddingCourse 'ENGE',3,4,'Math3',1
---------------------------H----------------------------------

GO
CREATE PROC Procedures_AdminLinkInstructor
@instructorID int,
@courseID int,
@slotID int
AS
UPDATE Slot SET course_id=@courseID, instructor_id=@instructorID WHERE slot_id=@slotID;
if not exists(Select * FROM Instructor_Course where course_id=@courseID AND instructor_id=@instructorID)
INSERT INTO Instructor_Course VALUES(@courseID,@instructorID);; --? necessary right?
GO
--drop proc Procedures_AdminLinkInstructor
EXEC Procedures_AdminLinkInstructor 1,1,1
---------------------------I----------------------------------

GO
CREATE PROC Procedures_AdminLinkStudent
@instructorID int,
@studentID int, 
@courseID int,
@semester_code varchar (40)
AS
INSERT INTO Student_Instructor_Course_Take(student_id, course_id, instructor_id, semester_code)
VALUES(@studentID, @courseID, @instructorID, @semester_code);;
GO
EXEC Procedures_AdminLinkStudent 1,1,1,1
---------------------------J----------------------------------

GO
CREATE PROC Procedures_AdminLinkStudentToAdvisor
@studentID int,
@advisorID int
AS
UPDATE Student SET advisor_id=@advisorID WHERE student_id=@studentID;;
GO
EXEC Procedures_AdminLinkStudentToAdvisor 1,1
---------------------------K----------------------------------

GO
CREATE PROC Procedures_AdminAddExam
@Type varchar(40),
@date datetime, 
@courseID int
AS
INSERT INTO MakeUp_Exam VALUES (@date,@Type,@courseID);;
GO
EXEC Procedures_AdminAddExam 'Second_makeup','2020-04-03',1
---------------------------L----------------------------------

GO
CREATE PROC Procedures_AdminIssueInstallment
@paymentID int
AS

declare @NumInstallments int,
@PaymentDeadline datetime, 
@TotalAmount int, 
@Paymentstart_date datetime, 
@num int =0,
@InstallmentAmount decimal(10,2) --? right datatype?

SELECT @NumInstallments = n_installments,
@PaymentDeadline = deadline,
@TotalAmount = amount,
@Paymentstart_date = start_date FROM Payment WHERE Payment.payment_id=@paymentID

SET @InstallmentAmount=@TotalAmount/@NumInstallments
WHILE @NumInstallments>@num
BEGIN 
   declare @start datetime=DATEADD(MONTH,@num,@Paymentstart_date),
   @end datetime=DATEADD(MONTH,@num+1,@Paymentstart_date)
   SET @num+=1
   INSERT INTO Installment VALUES(@paymentID,@end,@InstallmentAmount,'notPaid',@start)
END;
GO


--INSERT INTO PAYMENT VALUES(22,3000,'12-1-2020',3,'notPaid',0,'9-1-2020',1,1);
EXEC Procedures_AdminIssueInstallment 22
---------------------------M----------------------------------


GO
CREATE PROC Procedures_AdminDeleteCourse
@courseID int
AS
DELETE FROM Slot WHERE course_id=@courseID;
DELETE FROM Course WHERE course_id=@courseID;;
GO

EXEC Procedures_AdminDeleteCourse 2;
---------------------------N----------------------------------

GO
CREATE PROC Procedure_AdminUpdateStudentStatus
@StudentID int
AS
UPDATE Student SET financial_status=
CASE WHEN EXISTS (
SELECT S.student_id 
FROM Student S INNER JOIN
     Payment P on S.student_id=P.student_id INNER JOIN 
     Installment I on P.payment_id=I.payment_id
WHERE S.student_id=@StudentID AND I.status='notPaid' AND I.deadline<GETDATE()
) THEN 0 ELSE 1 END;
GO
EXEC Procedure_AdminUpdateStudentStatus 1
---------------------------O----------------------------------

go

CREATE VIEW all_Pending_Requests AS  --? have both advisor and student IDs and names?
SELECT R.request_id, R.type, R.comment,R.credit_hours,R.course_id,R.student_id,S.f_name,S.l_name, R.advisor_id,
A.name AS 'advisor_name'
FROM Request R INNER JOIN 
     Student S ON R.student_id=S.student_id INNER JOIN
     Advisor A ON R.advisor_id=A.advisor_id
WHERE R.status='pending';
go
 SELECT * FROM all_Pending_Requests;
 ---------------------------P----------------------------------

GO 
CREATE PROC Procedures_AdminDeleteSlots( --? why have semester if is_offered tells us all not offered courses
@current_semester varchar (40))
AS
SELECT course_id INTO NotOfferedCourses FROM Course_Semester CS 
WHERE  semester_code<> @current_semester;
DELETE FROM Slot 
WHERE course_id IN (SELECT * FROM NotOfferedCourses);
DROP TABLE NotOfferedCourses;;
GO

exec Procedures_AdminDeleteSlots 'w23';


---------------------------Q----------------------------------


GO
CREATE FUNCTION dbo.FN_AdvisorLogin
(
    @Advisor_ID int ,
    @password varchar(40)

)
RETURNS Bit 
AS
Begin
DECLARE @confirm bit=0
IF @password=
(SELECT password from Advisor WHERE advisor_id=@Advisor_ID)
set @confirm=1

return @confirm
end;
go
 declare @output bit=dbo.FN_AdvisorLogin(1,'cheese');print(@output);

 ---------------------------R----------------------------------

GO
CREATE PROC Procedures_AdvisorCreateGP
@semester_code varchar(40),
@expected_graduation_date DATE,  
@sem_credit_hours int, 
@advisor_id int, 
@student_id int
AS
if((SELECT acquired_hours FROM STUDENT WHERE student_id=@student_id)>157)
insert into Graduation_Plan values(@semester_code,@sem_credit_hours,@expected_graduation_date,@advisor_id,@student_id);
else
print 'can not have grad plan yet';
GO
exec Procedures_AdvisorCreateGP 's23','3/2/2030',35,1,1
--drop proc Procedures_AdvisorCreateGP
---------------------------S----------------------------------

GO
CREATE PROC Procedures_AdvisorAddCourseGP
@student_id int,
@Semester_code varchar(40), 
@course_name varchar(40)
as
declare @planID int
SELECT @planID=plan_id from Graduation_Plan where semester_code=@Semester_code and student_id=@student_id
if @planID is not null
INSERT INTO GradPlan_Course values(@planID,@Semester_code, (select course_id from Course where name=@course_name));;
GO
exec Procedures_AdvisorAddCourseGP 1,'s23','math'
---------------------------T----------------------------------

GO
CREATE PROC Procedures_AdvisorUpdateGP
@expected_grad_date date, @studentID int
AS
Update Graduation_Plan 
Set expected_grad_date = @expected_grad_date
Where student_id = @studentID;;
GO
exec  Procedures_AdvisorUpdateGP 'S29',1
---------------------------U----------------------------------

GO
CREATE PROC Procedures_AdvisorDeleteFromGP
@studentID int, 
@semester_code varchar(40), 
@courseID int
as
delete from GradPlan_Course
where course_id=@courseID and plan_id=(select plan_id from Graduation_Plan where semester_code=@semester_code and student_id=@studentID)
GO
exec Procedures_AdvisorDeleteFromGP 1,'s23',1;
---------------------------V----------------------------------

GO
CREATE FUNCTION dbo.FN_Advisors_Requests(
@advisorID int
)
returns Table
as
return SELECT * FROM Request 
WHERE @advisorID = Request.advisor_id;

GO
SELECT * FROM dbo.FN_Advisors_Requests(1);

---------------------W-----------------------
GO
CREATE PROC Procedures_AdvisorApproveRejectCHRequest
@RequestID int,
@Current_semester_code varchar(40)
AS 
BEGIN
    DECLARE @assigned_hours int,@advisor_id int,@req_advisor int,@student_id int, @credit_hrs int,@major varchar(40),@all_hours int,@stud_hours int,@missing_hours int;

    SELECT @credit_hrs = credit_hours, @student_id = student_id,@req_advisor=advisor_id
    FROM Request
    WHERE @RequestID = request_id;

    SELECT @assigned_hours = assigned_hours, @major=major, @advisor_id=advisor_id
    FROM Student
    WHERE @student_id = student_id;

    IF ((Select type from Request where request_id=@requestID) not like '%credit%') OR(@req_advisor<>@advisor_id)
        print 'this request is not valid'
    ELSE
    BEGIN
    

    --find if student has missed courses and accordingly how many total assigned hours should he/she have
    SELECT @all_hours=sum(C.credit_hours) FROM
    Course C INNER JOIN Course_Semester CS ON C.course_id=CS.course_id
    WHERE CS.semester_code=@Current_semester_code AND C.major=@major;
    IF @all_hours IS NULL SET @all_hours=0;
    --PRINT 'ALL' ;
    --PRINT @all_hours;
    SELECT @stud_hours =sum(C.credit_hours) FROM
    Course C INNER JOIN Student_Instructor_Course_Take SICT ON C.course_id=SICT.course_id
    WHERE SICT.student_id=@student_id AND SICT.semester_code=@Current_semester_code;
    IF @stud_hours IS NULL SET @stud_hours=0;
    --PRINT 'STUD' ;
    --PRINT @stud_hours;
    SET @missing_hours=@all_hours-@stud_hours; --missing is max value for assigned hours and capped by 34 too
    
    IF  (
        (SELECT gpa FROM Student WHERE student_id = @student_id) <= 3.7 AND
        @credit_hrs < 4 AND @credit_hrs > 0 AND 
         (
           (@assigned_hours IS NULL AND @credit_hrs<=@missing_hours AND @credit_hrs<=34) OR
           (@assigned_hours IS NOT NULL AND @assigned_hours+@credit_hrs<=34 AND @assigned_hours+@credit_hrs<=@missing_hours) 
          )
        )
    BEGIN
        UPDATE Request SET status = 'approved'
        WHERE @RequestID = request_id;
        PRINT 'Request Approved';
        
        UPDATE Student SET assigned_hours =(case when @assigned_hours IS NULL then @credit_hrs
                                            else @assigned_hours + @credit_hrs end)
        WHERE @student_id = student_id;
        DECLARE @CurrDate datetime = GETDATE();
        DECLARE @paymenttID int,@deadline datetime,@amount int,@total_amount int;

        SELECT TOP 1 @paymenttID=i.payment_id, @deadline=i.deadline
        FROM Installment i
        INNER JOIN Payment p ON p.payment_id = i.payment_id
        INNER JOIN Student s ON s.student_id = p.student_id
        WHERE s.student_id = @student_id AND i.status = 'notPaid'
        ORDER BY DATEDIFF(DAY, @CurrDate, i.deadline);
        UPDATE Installment SET amount=amount+(1000*@credit_hrs) WHERE Installment.deadline=@deadline AND Installment.payment_id=@paymenttID;
        UPDATE Payment SET amount=amount+(1000*@credit_hrs) WHERE payment_id=@paymenttID;
    END
    ELSE
    BEGIN
        UPDATE Request SET status = 'rejected'
        WHERE @RequestID = request_id;
        PRINT 'Request Rejected';
    END
    END
    END;
GO

--DROP PROC Procedures_AdvisorApproveRejectCHRequest
EXEC Procedures_AdvisorApproveRejectCHRequest 3, 'S23'

--------------------X------------------------ 
GO
CREATE PROC Procedures_AdvisorViewAssignedStudents
@AdvisorID int, 
@major varchar(40)
as
SELECT DISTINCT Student.student_id, Student.f_name+ ' '+Student.l_name as name, Student.major, Course.name as course_name
from Student left outer join Student_Instructor_Course_Take on Student.student_id=Student_Instructor_Course_Take.student_id
left outer join Course on Course.course_id=Student_Instructor_Course_Take.course_id
where Student.advisor_id=@AdvisorID and Student.major=@major;;
GO
exec Procedures_AdvisorViewAssignedStudents 2,Engineering
--drop PROC Procedures_AdvisorViewAssignedStudents
--------------------Y------------------------  
GO
CREATE PROC Procedures_AdvisorApproveRejectCourseRequest  
@RequestID int,
@current_semester_code varchar(40)
AS

DECLARE @courseID int,
@assigned_hours int,
@credit_hrs int,
@studentID int,
@advisorID int,
@req_advisor int,
@major varchar(40)

SELECT @courseID=course_id,@studentID=student_id,@req_advisor=advisor_id FROM Request 
WHERE @RequestID=request_id;

SELECT @advisorID=advisor_id,@major=major FROM Student WHERE @studentID=student_id

IF (((Select type from Request where request_id=@requestID) not like '%course%')OR(@advisorID<>@req_advisor))
print 'this request is invalid'
else 
begin

SELECT @assigned_hours=assigned_hours FROM Student
WHERE @studentID=student_id;

SELECT @credit_hrs=credit_hours FROM Course
WHERE course_id=@courseID

CREATE TABLE PreqTable(
prerequisite_course_id int primary key)

INSERT INTO PreqTable SELECT prerequisite_course_id FROM PreqCourse_course
WHERE course_id=@courseID;

IF(@assigned_hours-@credit_hrs>=0 
AND NOT EXISTS(
Select * from PreqTable 
EXCEPT(SELECT course_id
FROM Student_Instructor_Course_Take SCT WHERE
SCT.student_id=@studentID AND grade IS NOT NULL AND grade NOT IN ('F','FF','FA'))
          )
 AND EXISTS 
(SELECT CS.course_id FROM Course_Semester CS INNER JOIN Course C ON C.course_id=CS.course_id  WHERE 
semester_code=@current_semester_code AND C.course_id=@courseID AND C.major=@major)
)

BEGIN
UPDATE Request set status = 'approved' WHERE @RequestID = request_id;
PRINT 'approved'
UPDATE Student set assigned_hours=@assigned_hours-@credit_hrs WHERE student_id=@studentID;
INSERT INTO  Student_Instructor_Course_Take(student_id, course_id,semester_code) VALUES(@studentID, @courseID,@current_semester_code );
END

ELSE
BEGIN
UPDATE Request set status = 'rejected'
WHERE @RequestID = request_id
PRINT 'rejected'
END
DROP TABLE PreqTable
END;;
GO


EXEC Procedures_AdvisorApproveRejectCourseRequest 2,'W23'

--------------------Z------------------------ 
GO
CREATE PROC Procedures_AdvisorViewPendingRequests
@advisorID int
AS
Select R.request_id, R.type, R.comment,R.credit_hours,R.student_id,R.course_id 
FROM Request R WHERE R.status='pending' AND R.advisor_id=@advisorID;
GO
EXEC Procedures_AdvisorViewPendingRequests 1;

--*************** DOUBLE  LETTERS ********************

--------------------AA------------------------ 
GO
CREATE FUNCTION dbo.FN_StudentLogin
(
    @Student_ID int ,
    @password varchar(40)

)
RETURNS Bit 
AS
Begin
DECLARE @confirm bit =0

IF @password=(SELECT password FROM Student WHERE student_id=@Student_ID)
set @confirm=1

return @confirm
end;
GO
DECLARE @output bit=dbo.FN_StudentLogin(1,'batetes');print @output


--------------------BB------------------------ 
GO
CREATE PROC  Procedures_StudentaddMobile 
@StudentID int,@mobile_number varchar(40)
AS
INSERT INTO Student_Phone VALUES(@StudentID,@mobile_number);
GO
EXEC Procedures_StudentaddMobile 1, '+201004325'

--------------------CC------------------------ 
GO
CREATE FUNCTION dbo.FN_SemsterAvailableCourses
(@semester_code varchar (40))
returns table
AS return SELECT C.course_id,C.name 'course_name' FROM Course C INNER JOIN Course_Semester CS ON
C.course_id=CS.course_id WHERE CS.semester_code=@semester_code;
GO
SELECT * FROM dbo.FN_SemsterAvailableCourses ('W24')

--------------------DD------------------------ 
GO
CREATE PROCEDURE  Procedures_StudentSendingCourseRequest
@StudentID int,
@courseID int,
@type varchar(40),
@comment varchar(40)
AS
declare @advisor_id int=(SELECT advisor_id FROM Student WHERE student_id=@StudentID )
INSERT INTO Request(student_id,course_id,type,comment,advisor_id) VALUES(@StudentID,@courseID,@type,@comment,@advisor_id);;
GO
EXEC Procedures_StudentSendingCourseRequest 1, 1, 'course_request', 'asap'

--------------------EE------------------------ 
GO
CREATE PROCEDURE  Procedures_StudentSendingCHRequest
@StudentID int,
@credit_hours int,
@type varchar(40),
@comment varchar(40)
AS
declare @advisor_id int=(SELECT advisor_id FROM Student WHERE student_id=@StudentID )
INSERT INTO Request(student_id,type,comment,advisor_id,credit_hours) VALUES(@StudentID,@type,@comment,@advisor_id,@credit_hours);;
GO
EXEC Procedures_StudentSendingCHRequest 1, 10, 'credit_hours_request', 'asap'

--------------------FF------------------------ 
go
create function dbo.FN_StudentViewGP             
(
@student_ID int
)
returns table 
as return 
SELECT DISTINCT S.student_id,S.f_name+' '+S.l_name 'student_name', GP.plan_id,C.course_id,C.name 'course_name',GC.semester_code,GP.expected_grad_date,GP.semester_credit_hours,S.advisor_id
FROM Graduation_Plan GP INNER JOIN GradPlan_Course GC ON GC.plan_id=GP.plan_id
INNER JOIN Course C ON C.course_id=GC.course_id INNER JOIN Student S ON S.student_id=GP.student_id
WHERE GP.student_id=@student_ID;;
go
DROP FUNCTION dbo.FN_StudentViewGP 
Select * FROM dbo.FN_StudentViewGP (1)

--------------------GG------------------------ 
GO
CREATE FUNCTION dbo.FN_StudentUpcoming_installment
(
    @StudentID int
)
RETURNS date
AS 
BEGIN
    DECLARE @CurrDate datetime = GETDATE()
    DECLARE @date datetime

    SELECT TOP 1 @date = i.deadline
    FROM Installment i
    INNER JOIN Payment p ON p.payment_id = i.payment_id
    INNER JOIN Student s ON s.student_id = p.student_id
    WHERE s.student_id = @StudentID AND i.status = 'notPaid'
    ORDER BY DATEDIFF(DAY, @CurrDate, i.deadline)
    RETURN @date
END;
GO

--INSERT INTO Installment VALUES(49,'2-20-2001',20,'notPaid','1-20-2001')
--declare @output date=dbo.FN_StudentUpcoming_installment(1);print @output
declare @output date=dbo.FN_StudentUpcoming_installment(7);print @output

--------------------HH------------------------ 
GO
CREATE FUNCTION dbo.FN_StudentViewSlot
(
@courseID int, 
@instructorID int
)
returns table 
as
return
(
select 
s.slot_id, s.location, s.time, s.day, c.name as course_name, i.name as instructor_name from Slot s
INNER JOIN Course c on s.course_id = c.course_id
INNER JOIN Instructor i on s.instructor_id = i.instructor_id
where s.course_id = @courseID and s.instructor_id = @instructorID
);
GO
select * from dbo.FN_StudentViewSlot(1,1)

--------------------II------------------------
GO
CREATE PROC Procedures_StudentRegisterFirstMakeup   -- directly next semester
@StudentID int, @courseID int, @studentCurrent_semester varchar(40)
as

if exists( select 1 from Student_Instructor_Course_Take where student_id=@StudentID and course_id=@courseID and (grade is null or grade in ('FF','F','FA')) and exam_type='Normal')
and not exists(select 1 from Student_Instructor_Course_Take where student_id=@StudentID and course_id=@courseID AND (exam_type LIKE '%First%' OR exam_type LIKE '%Second%'))
and not exists (select 1 from Student_Instructor_Course_Take where student_id=@StudentID and course_id=@courseID and (grade is not null and grade not in ('FF','F','FA')) and exam_type='Normal') --not passed / handle same course with diff instructor
begin
declare @examid int, @next_semester varchar(40),@end_of_prev_semester date,@instructorID int
SELECT @end_of_prev_semester = end_date
FROM Semester WHERE @studentCurrent_semester = semester_code;


SELECT @instructorID = instructor_id
FROM Student_Instructor_Course_Take
WHERE student_id = @StudentID
  AND course_id = @courseID
  AND @studentCurrent_semester = semester_code;


SELECT TOP 1 @next_semester = semester_code
FROM Semester 
WHERE start_date >= @end_of_prev_semester
ORDER BY start_date;


select top 1 @examid = exam_id from Makeup_Exam 
where @courseID = course_id AND date>=@end_of_prev_semester AND type LIKE '%First%'
ORDER BY date;

INSERT INTO Exam_Student VALUES(@examid , @StudentID, @courseID);
INSERT INTO Student_Instructor_Course_Take(student_id,instructor_id,course_id,semester_code,exam_type) VALUES(@StudentID,@instructorID,@courseID,@next_semester,'First MakeUp');
end
else
begin
print 'Student is not eligible';
end
GO

exec Procedures_StudentRegisterFirstMakeup 6, 5, 'W23'
--drop proc Procedures_StudentRegisterFirstMakeup

---------------------JJ------------------------
go
CREATE FUNCTION dbo.FN_StudentCheckSMEligibility  
(@CourseID INT, @StudentID INT)
RETURNS BIT
AS
BEGIN
    DECLARE @OUTPUT BIT,@already_passed_course BIT;       
        set @OUTPUT =0;
        set @already_passed_course=case when(
          exists(select * from Student_Instructor_Course_Take WHERE student_id=@StudentID AND course_id=@CourseID
          AND grade is NOT NULL AND grade NOT IN ('FF','FA','F'))
          )then 1 else 0 end;

        IF @already_passed_course=0 AND NOT EXISTS(SELECT * FROM  Student_Instructor_Course_Take WHERE student_id=@StudentID AND course_id=@CourseID AND exam_type LIKE '%Second%') --assume can enter makeup only once
        BEGIN          
            DECLARE @FCC INT, @semnum int
            select @semnum=semester from Course where course_id=@CourseID
            if(@semnum%2=0)
            begin
            SELECT @FCC = COUNT(DISTINCT c.course_id)
            FROM Student_Instructor_Course_Take sict, Course c
            WHERE sict.course_id = c.course_id AND student_id = @StudentID AND c.semester%2=0
            AND (grade IN ('FF','FA','F') OR grade IS NULL);
            end
            ELSE
            begin
            SELECT @FCC = COUNT(DISTINCT c.course_id)
            FROM Student_Instructor_Course_Take sict, Course c
            WHERE sict.course_id = c.course_id AND student_id = @StudentID AND c.semester%2=1
            AND (grade IN ('FF','FA','F') OR grade IS NULL);
            end

            IF @FCC > 2
                SET @OUTPUT = 0;
            ELSE
                SET @OUTPUT = 1; 
        END  

    RETURN @OUTPUT;
END
go
--drop function dbo.FN_StudentCheckSMEligibility
declare @output bit=dbo.FN_StudentCheckSMEligibility(1,1);print @output

--------------------KK------------------------ 
GO
CREATE PROC Procedures_StudentRegisterSecondMakeup  --any time within or after the current semester assuming that current semester is 
                                                    --after first makeUp session
    @StudentID int, @courseID int, @student_current_semester varchar(40)
AS
BEGIN
    IF dbo.FN_StudentCheckSMEligibility(@courseID, @StudentID) = 1
    BEGIN
        DECLARE @e_id int, @sem_date date, @makeup_semester varchar(40), @makeup_date date;

        -- Retrieve the start date of the current semester
        SELECT @sem_date = start_date FROM Semester WHERE semester_code = @student_current_semester;

        -- Retrieve the first makeup exam ID and date for the specified course and semester
        SELECT TOP 1 @e_id = exam_id, @makeup_date = date FROM MakeUp_Exam
        WHERE course_id = @courseID AND type LIKE '%Second%' AND date >= @sem_date
        ORDER BY date;

        -- Retrieve the semester code for the makeup date
        SELECT @makeup_semester = semester_code FROM Semester WHERE @makeup_date BETWEEN start_date AND end_date;

        -- Insert records into Exam_Student and Student_Instructor_Course_Take tables
        INSERT INTO Exam_Student VALUES (@e_id, @StudentID, @courseID);
        INSERT INTO Student_Instructor_Course_Take(student_id, course_id, instructor_id, semester_code, exam_type)
        VALUES (@StudentID, @courseID, null, @makeup_semester, 'Second Makeup');
    END
    ELSE
    BEGIN
        PRINT('The student is not eligible to take the second makeup');
    END
END;;
GO
--drop proc Procedures_StudentRegisterSecondMakeup 
EXEC Procedures_StudentRegisterSecondMakeup 1,1, 'W23'
--------------------LL------------------------
GO
CREATE PROC Procedures_ViewRequiredCourses
@Student_ID int, @Current_semester_code Varchar (40)
AS
declare @startOfCurrent date, @stud_semester int,
@major varchar(40)

SELECT @startOfCurrent=start_date from Semester 
WHERE semester_code=@Current_semester_code;

SELECT @major=major, @stud_semester=semester FROM Student
WHERE student_id=@Student_ID

Select CS.course_id INTO AllCourses FROM  --all major's courses in previous semesters that are offered this semester
Course_Semester CS INNER JOIN
Course C ON C.course_id=CS.course_id
WHERE C.semester<@stud_semester AND @current_semester_code=CS.semester_code AND C.major=@major

SELECT * INTO Unattended FROM --case not in takes table 
(
(Select * FROM AllCourses)
EXCEPT
(Select course_id FROM Student_Instructor_Course_Take 
WHERE student_id=@Student_ID)
)as temp


SELECT SICT.course_id INTO Failed FROM Student_Instructor_Course_Take SICT --case in takes table and failed
WHERE SICT.student_id=@Student_ID AND NOT(grade LIKE '%F%' OR grade IS NULL) AND dbo.FN_StudentCheckSMEligibility(course_id,@Student_ID)=0 AND
EXISTS(SELECT 1 FROM Course_Semester CS WHERE CS.semester_code=@Current_semester_code AND CS.course_id=SICT.course_id)

SELECT *  INTO Result FROM Failed
INSERT INTO Result Select * FROM Unattended

SELECT DISTINCT C.* FROM Result R INNER JOIN Course C ON C.course_id=R.course_id
DROP TABLE Unattended;
DROP TABLE Failed;
DROP TABLE AllCourses;
DROP TABLE Result;;
GO
--drop proc Procedures_ViewRequiredCourses
exec Procedures_ViewRequiredCourses 1, 'w23'

--------------------MM------------------------ 
GO
CREATE PROC Procedures_ViewOptionalCourse
@StudentID int , @current_semester_code varchar(40)
AS

SELECT  DISTINCT C.*  FROM Course C INNER JOIN Course_Semester CS ON C.course_id = CS.course_id INNER JOIN Student S ON S.major=C.major
WHERE  @current_semester_code=CS.semester_code  AND C.semester>=S.semester AND
NOT EXISTS(SELECT * FROM Student_Instructor_Course_Take SICT WHERE student_id=@StudentID AND SICT.course_id=C.course_id) AND
NOT EXISTS((SELECT PC.prerequisite_course_id FROM PreqCourse_course PC WHERE PC.course_id=C.course_id)
            EXCEPT 
            (SELECT course_id FROM Student_Instructor_Course_Take WHERE student_id=@StudentID AND grade IS NOT NULL AND grade NOT IN ('F','FF','FA')));

GO
--drop proc Procedures_ViewOptionalCourse
EXEC Procedures_ViewOptionalCourse 2 , 'W24'
--------------------NN------------------------ 
go
create proc Procedures_ViewMS 
@StudentID int
as
declare @major varchar(40)
SELECT @major=major FROM Student WHERE @StudentID=student_id

Select C.* INTO AllMajor FROM Course C WHERE C.major= @major  --all major courses
SELECT C.* INTO PassedOrTaking FROM Course C INNER JOIN Student_Instructor_Course_Take SICT  --taking=null grade  passed=not like F
ON C.course_id=SICT.course_id 
WHERE SICT.student_id=@StudentID AND (SICT.grade IS NULL OR SICT.grade NOT IN('F','FF','FA'))

SELECT * FROM AllMajor EXCEPT SELECT * FROM PassedOrTaking
drop table AllMajor;
drop table PassedOrTaking;
go
--drop proc Procedures_ViewMS
exec Procedures_ViewMS 2
--------------------OO------------------------
GO
CREATE PROC Procedures_ChooseInstructor
@studentID int, @instructorID int, @courseID int, @current_semester_code varchar(40)
AS

UPDATE Student_Instructor_Course_Take SET 

instructor_id=@instructorID
where 
course_id=@courseID and
student_id=@studentID and
semester_code=@current_semester_code;
go
exec Procedures_ChooseInstructor 1,2,1,'W23'

select * from Student_Instructor_Course_Take
select * from Instructor
select * from Course
select * from Student
select * from MakeUp_Exam
select * from Semester


