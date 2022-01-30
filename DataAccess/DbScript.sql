use Test;

Create Table Students(
	StudentId int not null identity(1,1),
	StudentName nvarchar(50) not null,
	constraint pk_students_id primary key(StudentId)
);

Create Table Courses(
	CourseId int not null Identity(1,1),
	CourseName nvarchar(50) not null,
	CourseDescription nvarchar(250)
	constraint pk_courses_id primary key(CourseId)
);

Create Table StudentCourses(
	StudentId int not null,
	CourseId int not null,
	constraint fk_studentCourses_studentId_Students_studentsId foreign key
	(StudentId) references Students(StudentId),
	constraint fk_studentCourses_courseId_Courses_courseId foreign key
	(CourseId) references Courses(CourseId)
);