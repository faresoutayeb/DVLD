
 RESTORE FILELISTONLY
FROM DISK = 'C:\DVLD Project Final\DataBase\DVLD.bak';


RESTORE DATABASE DVLD
FROM DISK = 'C:\DVLD Project Final\DataBase\DVLD.bak'
WITH 
MOVE 'DVLD' TO 'C:\DVLD Project Final\DataBase\DataBaseFiles\DVLD.mdf',
MOVE 'DVLD_log' TO 'C:\DVLD Project Final\DataBase\DataBaseFiles\DVLD_log.ldf',
REPLACE

ALTER AUTHORIZATION ON DATABASE::DVLD TO sa;


  SELECT  top 1
            Tests.TestID, 
            Tests.TestAppointmentID,
            Tests.TestResult, 
			Tests.Notes, 
            Tests.CreatedByUserID,
            Applications.ApplicantPersonID
    FROM   Tests  
            INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
            INNER JOIN LocalDrivingLicenseApplications on TestAppointments.LocalDrivingLicenseApplicationID  ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID  
            INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
    WHERE        
        (Applications.ApplicantPersonID = @PersonID) 
        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
        AND ( TestAppointments.TestTypeID=@TestTypeID)
    ORDER BY Tests.TestAppointmentID DESC




    select RoleName from Roles



    ALTER TABLE dbo.people
ADD CONSTRAINT UQ_NationalNo UNIQUE (NationalNo);


 select  PersonID ,NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth, Gendor  ,
Address,Phone,Email,NationalityCountryID,ImagePath from People ;

select * from people


select  
                            PersonID 
                            NationalNo,
                            FirstName,
                            SecondName,
                            ThirdName,
                            LastName,
                            DateOfBirth,
                            Gendor=
                            case 
                                 when People.Gendor = 0 then 'Male' 
                            else
                                'Female'
                            end ,
                            Address,
                            Phone,
                            Email,
                            Countries.CountryID,
                            Countries.CountryName,
                            People.ImagePath

                            from People 
                            inner join countries on Countries.CountryID = People.NationalityCountryID 
                            order by People.FirstName


delete people 
where People.PersonID=1027


delete people where People.NationalNo = @NationalNo


SELECT Users.* FROM Users WHERE Users.UserName = @UserName and Users.Password = @Password


SELECT Users.* FROM Users 
inner join People On Users.PersonID=People.PersonID
WHERE People.NationalNo = NationalNo



SELECT top 1 TotalApplicationTypeCount = count(*) FROM ApplicationTypes


SELECT top 1 TotalTestsTypeCount = count(*) FROM TestTypes


SELECT top 1 Found=1
FROM LocalDrivingLicenseApplications 
    INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
    INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID

WHERE
(LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = 1)  AND(TestAppointments.TestTypeID = 2)
ORDER BY TestAppointments.TestAppointmentID desc

SELECT top 1 dbo.Tests.TestResult

FROM LocalDrivingLicenseApplications 
    INNER JOIN TestAppointments 
            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
    INNER JOIN Tests 
            ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
    WHERE
    (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
    AND(TestAppointments.TestTypeID = @TestTypeID)
    ORDER BY TestAppointments.TestAppointmentID desc






    SELECT top 1 TestResult
                      FROM LocalDrivingLicenseApplications 
                            INNER JOIN TestAppointments 
                                    ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            INNER JOIN Tests 
                                    ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc



                            select Top 1 dbo.Tests.TestResult  from dbo.Tests  
inner join dbo.TestAppointments on  dbo.TestAppointments.TestAppointmentID = dbo.Tests.TestAppointmentID 
where   dbo.TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
and dbo.TestAppointments.TestTypeID = @TestTypeID order by  dbo.Tests.TestID desc



select IsHasMinimaumAge = 1  from LocalDrivingLicenseApplications
inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID

inner join People On Applications.ApplicantPersonID=People.PersonID
where  People.PersonID=1 and LicenseClasses.LicenseClassID = 1 and  Year(People.DateOfBirth) >= LicenseClasses.MinimumAllowedAge


select * from people


select top 1  dbo.TestAppointments.AppointmentDate from  dbo.TestAppointments  
inner join  dbo.LocalDrivingLicenseApplications on  dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =  dbo.TestAppointments.LocalDrivingLicenseApplicationID
where  
 dbo.TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
and   dbo.TestAppointments.TestTypeID = @TestTypeID 
and  dbo.LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID
order by dbo.TestAppointments.AppointmentDate  desc
 





 select top 1 TotalDriversCount=count(*) from Drivers

select top 1 ActiveLicensesCount = count(*)  from dbo.Licenses 
where dbo.Licenses.IsActive=1;




select top 1 TotalDriversCount=count(*) from Drivers
inner join  Licenses on Drivers.DriverID=Licenses.DriverID
where dbo.Licenses.IsActive=1



select top 1 TotalDriversCount=count(*) from Drivers
        where dbo.Drivers.CreatedDate >=  (DATEADD(month,-1,GETDATE()));
        
select (DATEADD(month,5,GETDATE()))



select top 1 dbo.Drivers.CreatedDate from dbo.drivers
order by dbo.drivers.CreatedDate desc;


select top 1 LicensesCount = count(*)  from dbo.Licenses
INNER JOIN Drivers on Drivers.DriverID=Licenses.DriverID
where Drivers.PersonID=@PersonID and dbo.Licenses.IsActive=@IsActive


select top 1 LicensesCount = count(*)  from dbo.InternationalLicenses
INNER JOIN Drivers on Drivers.DriverID=dbo.InternationalLicenses.DriverID
where Drivers.PersonID=@PersonID


select top 1 LicensesCount = count(*)  from dbo.InternationalLicenses
INNER JOIN Drivers on Drivers.DriverID=dbo.InternationalLicenses.DriverID
where Drivers.PersonID=1029;



select top 1 COUNT(*) from DetainedLicenses where IsReleased=0; 


select top 1 TotalDetainedFees =  sum(DetainedLicenses.FineFees) from DetainedLicenses where IsReleased=0; 

select top 1 COUNT(*) from DetainedLicenses
where DetainedLicenses.IsReleased = 0 and  DetainedLicenses.DetainDate> DATEADD(MONTH,-1,GETDATE())

select top 1 COUNT(*) from DetainedLicenses where DetainedLicenses.IsReleased = 0 and  DetainedLicenses.ReleaseDate> DATEADD(MONTH,-1,GETDATE());



select top 1 DetainedLicenses.DetainDate from DetainedLicenses order by DetainedLicenses.DetainDate desc ;


select top 1 DetainedLicenses.ReleaseDate from DetainedLicenses order by DetainedLicenses.ReleaseDate desc ;


select sum(DetainedLicenses.FineFees) from dbo.DetainedLicenses where dbo.DetainedLicenses.IsReleased=1

 SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where (DriverID=@DriverID) and (GetDate() between IssueDate and ExpirationDate  )  and  InternationalLicenses.IsActive =1 
                            order by ExpirationDate Desc;



select top 1 LicensesCount = count(*)  from dbo.InternationalLicenses  where (GETDATE() not between InternationalLicenses.IssueDate and InternationalLicenses.ExpirationDate)


select top 1 LicensesCount = count(*)  from dbo.InternationalLicenses  where (InternationalLicenses.ExpirationDate >= (DATEADD(MONTH,-1,GETDATE())))

select top 1 LicensesCount = count(*)  from dbo.InternationalLicenses  where (InternationalLicenses.IssueDate >= (DATEADD(MONTH,-1,GETDATE())))

select top 1 LicensesCount = count(*)  from dbo.InternationalLicenses  
where InternationalLicenses.ExpirationDate between (DATEADD(DAY,-@FromDays,InternationalLicenses.ExpirationDate)) and (DATEADD(DAY,-@ToDays,InternationalLicenses.ExpirationDate);

select top 1 LicensesCount = count(*)  from dbo.InternationalLicenses  
where InternationalLicenses.IssueDate between (DATEADD(DAY,-@FromDays,InternationalLicenses.IssueDate)) and (DATEADD(DAY,-@ToDays,InternationalLicenses.IssueDate);


select top 5  

Inter.InternationalLicenseID,
FullName=People.FirstName+ ISNULL(People.SecondName,'')+ ISNULL(People.ThirdName,'')+People.SecondName,
Countries.CountryName,
LicenseClasses.ClassName,
DaysUntilExpiring=  DATEDIFF(DAY,Inter.ExpirationDate,GETDATE())
from InternationalLicenses  Inter 

inner join Drivers on Inter.DriverID = Drivers.DriverID
inner join People on Drivers.PersonID = People.PersonID
inner join Countries on People.NationalityCountryID = Countries.CountryID
inner join Licenses on Inter.IssuedUsingLocalLicenseID = Licenses.LicenseID
inner join LicenseClasses on People.NationalityCountryID = LicenseClasses.LicenseClassID
where Inter.ExpirationDate  between  (DATEADD(MONTH,-1,GETDATE())) and GETDATE()
order by Inter.ExpirationDate desc 


select top 1 dbo.InternationalLicenses.IssueDate from dbo.InternationalLicenses order by dbo.InternationalLicenses.IssueDate desc 


select top 1  dbo.InternationalLicenses.InternationalLicenseID,  dbo.InternationalLicenses.ExpirationDate from dbo.InternationalLicenses order by dbo.InternationalLicenses.ExpirationDate desc 


select Top 5 DetainID, DetainedLicenses.IsReleased,DetainedLicenses.DetainReason,DetainDate,ReleaseDate,LastActionDateTime from DetainedLicenses
order by DetainedLicenses.LastActionDateTime desc;


INSERT INTO DetainReasons (ReasonText)
VALUES
('Driving Under the Influence of Alcohol'),
('Driving Under the Influence of Drugs'),
('Excessive Speeding'),
('Reckless Driving'),
('Dangerous Driving'),
('Driving Against Traffic'),
('Driving Without a Valid License'),
('Driving With an Expired License'),
('Driving With a Suspended License'),
('Driving With a Revoked License'),
('Using a Forged License'),
('Using Someone Else''s License'),
('Refusing a Traffic Police Order'),
('Leaving the Scene of an Accident'),
('Causing a Serious Traffic Accident'),
('Repeated Traffic Violations'),
('Serious Traffic Violation'),
('Multiple Speeding Violations'),
('Illegal Overtaking'),
('Dangerous Overtaking'),
('Running a Red Light'),
('Ignoring a Stop Sign'),
('Driving Without Required Documents'),
('Driving an Unregistered Vehicle'),
('Driving an Uninsured Vehicle'),
('Driving a Vehicle Without Required Safety Equipment'),
('Driving With Defective Brakes'),
('Driving With Unsafe Vehicle Conditions'),
('Using a Mobile Phone While Driving'),
('Distracted Driving'),
('Driving Without Wearing a Seat Belt'),
('Allowing an Unauthorized Person to Drive'),
('Driving With More Passengers Than Allowed'),
('Illegal Racing'),
('Street Racing'),
('Endangering Other Road Users'),
('Failure to Follow Traffic Signs'),
('Failure to Give Way'),
('Illegal U-Turn'),
('Illegal Parking Causing Serious Obstruction'),
('Driving on a Restricted Road'),
('Driving During a License Restriction Period'),
('Failure to Comply With License Conditions'),
('Violation of Court-Ordered Driving Restrictions'),
('License Suspended by Court Order'),
('License Suspended for Medical Reasons'),
('License Suspended for Repeated Violations'),
('License Detained by Traffic Authority'),
('License Detained Pending Investigation'),
('License Detained Pending Court Decision'),
('Other Traffic-Related Violation');




select top 1  DetainedLicensesThisMonth=count(*) from DetainedLicenses 
where DetainedLicenses.IsReleased=0 and Year(DetainedLicenses.DetainDate)=YEAR(GETDATE()) and Month(DetainedLicenses.DetainDate)=Month(GETDATE())


select top 1 DetainedLicensesCountInLast30Days = COUNT(*) from DetainedLicenses where dbo.DetainedLicenses.IsReleased = 0 and  dbo.DetainedLicenses.DetainDate> DATEADD(MONTH,-1,GETDATE());


select   top  6  DetainReasons.ReasonText, TotalCount = count(*) from DetainedLicenses 
inner join DetainReasons on DetainReasons.DetainReasonID = DetainedLicenses.DetainReasonID 
group by DetainReasons.ReasonText order by  TotalCount desc 
 
 select Top 5 DetainID, IsReleased,DetainReasons.ReasonText,DetainDate,ReleaseDate,LastActionDateTime from DetainedLicenses
 inner join DetainReasons on DetainReasons.DetainReasonID=DetainedLicenses.DetainReasonID
                                order by DetainedLicenses.LastActionDateTime desc;


                                
UPDATE Users
    SET Users.MarkForDelete = 1,
    Users.IsActive=0,
    Users.IsLocked=1
                    
    WHERE UserID = @UserID





                    ALTER TABLE Users
ADD CONSTRAINT UQ_Users_UserName UNIQUE (UserName);





select top 1 ActiveUsersCount = count(*) from Users where Users.IsActive=1

select top 1 RolesDefinedUsersCount = count(*) from dbo.UserPermissions 
inner join Users on Users.UserID = UserPermissions.UserID
where Users.UserID = dbo.UserPermissions.UserID

select TOP 1   OnlineUsersCount= count(*) from dbo.UsersLogins
inner join Users on Users.UserID = UsersLogins.UserID
where UsersLogins.LogoutDateTime = null and USERs.MarkForDelete=0



select UsersNeverLogedinCount = count(*) from dbo.UsersLogins
inner join Users on Users.UserID <> UsersLogins.UserID
where Users.MarkForDelete=0


select top 1 LastLogedInUserDateTime= UsersLogins.LoginDateTime from UsersLogins
order by UsersLogins.LoginDateTime desc;




select CurrentRole.RoleName as[Role Name],
 Users = (select top 1  count(*) from dbo.Users Where dbo.Users.RoleID = CurrentRole.RoleID)

,dbo.UserPermissions.Permissions,CurrentRole.Description
from dbo.Roles as CurrentRole
inner join dbo.Users on dbo.Users.RoleID = CurrentRole.RoleID
inner join dbo.UserPermissions  on dbo.Users.UserID=dbo.UserPermissions.UserID


select top 1 RolesDefinedUsersCount = count(*) from dbo.Users 
where Users.RoleID !=null and Users.MarkForDelete=0; 


SELECT * FROM Users WHERE UserID = @UserID and Users.MarkForDelete=0


SELECT 
        CurrentUserLog.UserLoginID,
        CurrentUserLog.UserID,
        CurrentUserLog.LoginDateTime,
        CurrentUserLog.LogoutDateTime
        FROM UsersLogs CurrentUserLog
        INNER JOIN Users CurrentUser
        ON CurrentUserLog.UserID = CurrentUser.UserID
        WHERE CurrentUser.UserName = @UserName

        ORDER BY CurrentUserLog.LoginDateTime DESC



select top 1 count(*) from People

  select IsHasMinimaumAge = 1  from LocalDrivingLicenseApplications
                        inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                        inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID

                        inner join People On Applications.ApplicantPersonID=People.PersonID
     where  People.PersonID = @PersonID  and 
     
     LicenseClasses.LicenseClassID = @LicenseClassID and 
     
     Year(GETDATE())-YEAR(People.DateOfBirth) >= LicenseClasses.MinimumAllowedAge;
                        

INSERT INTO Roles
(
    RoleName,
    Permissions,
    Description
)
VALUES

-- 1
(
    'System Administrator',
    4294967295,
    'Full access to all system features and permissions.'
),

-- 2
(
    'User Manager',
    127,
    'Manages people and system users, including adding, editing, deleting users and changing passwords.'
),

-- 3
(
    'People Manager',
    7,
    'Manages people records, including adding, editing and deleting people.'
),

-- 4
(
    'Application Manager',
    8064,
    'Manages driving license applications, application types and application test types.'
),

-- 5
(
    'Local License Officer',
    516096,
    'Manages local driving licenses, drivers, license issuance, renewal, replacement and license history.'
),

-- 6
(
    'International License Officer',
    7340032,
    'Manages international driving licenses and their issuance and viewing.'
),

-- 7
(
    'Test Manager / Examiner',
    58720256,
    'Manages test appointments, schedules tests and performs driving tests.'
),

-- 8
(
    'Application & Test Officer',
    92274560,
    'Manages driving license applications and the scheduling and execution of tests.'
),

-- 9
(
    'Detention Officer',
    1006632960,
    'Manages detained licenses, including detaining, releasing and viewing detained licenses.'
),

-- 10
(
    'Application Type Manager',
    1073741824,
    'Manages application types used throughout the system.'
),

-- 11
(
    'Test Type Manager',
    2147483648,
    'Manages test types used throughout the system.'
),

-- 12
(
    'Application Types & Test Types Manager',
    3221225472,
    'Manages both application types and test types.'
),

-- 13
(
    'Receptionist',
    25231367,
    'Handles people records, applications and test appointment scheduling.'
),

-- 14
(
    'License Service Officer',
    516224,
    'Handles day-to-day local driving license services and driver information.'
),

-- 15
(
    'Test Examiner',
    33554560,
    'Views applications and performs scheduled driving tests.'
),

-- 16
(
    'Test Appointment Officer',
    25165952,
    'Manages test appointments and schedules tests for applicants.'
),

-- 17
(
    'License Viewer',
    540016640,
    'Read-only access to driver, local license, international license, license history and detained license information.'
),

-- 18
(
    'Application Viewer',
    128,
    'Read-only access to driving license applications.'
);



select * from roles


select 
CurrentUser.UserID as [User ID],
[Full Name]= People.FirstName+' '+ISNULL(People.SecondName,'') + ISNULL(People.ThirdName,'')  +' '+People.LastName,
CurrentUser.UserName as [User Name] ,
Roles.RoleName as [Role Name],
[Is Active]= 
case
when CurrentUser.IsActive = 1 then 'Active'
else 'Inactive'
end
,

(select Top 1 UsersLogs.LoginDateTime from UsersLogs where UsersLogs.UserID = CurrentUser.UserID order by UsersLogs.LoginDateTime desc ) as [Last Login]

from Users as CurrentUser
inner join People on People.PersonID=CurrentUser.PersonID
inner join Roles on Roles.RoleID=CurrentUser.RoleID


select TotalUsersCountSignUpInPeriod=count(*) from dbo.Users
where (dbo.Users.SignUpDateTime  >=@StartDateTime) and  (dbo.Users.SignUpDateTime  <@EndDateTime)



SELECT TodayLocksCount = COUNT(*)
                         FROM Lockings
                         WHERE LockedDateTime >= CAST(GETDATE() AS DATE)
                         AND LockedDateTime < DATEADD(DAY, 1, CAST(GETDATE() AS DATE));



                         SELECT COUNT(*)
                         FROM Lockings
                         WHERE LockedDateTime >=
                               DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
                         AND LockedDateTime <
                               DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))




  select 1  from users
  
  Where users.UserName=@UserName;



  select count(*) from Licenses where Licenses.LicenseClass=3 and Licenses.IsActive=1;

  select count(*) from Licenses where Licenses.IsActive=1;



    SELECT TotalActiveInternationalDriverLicensesCount = COUNT(*)
            FROM dbo.InternationalLicenses
            INNER JOIN Drivers ON Drivers.DriverID = dbo.InternationalLicenses.DriverID
            WHERE Drivers.PersonID = @PersonID and InternationalLicenses.IsActive=1;

  


  ALTER TABLE People
ADD CreatedDateTime DATETIME NOT NULL
    CONSTRAINT DF_People_CreatedDateTime DEFAULT GETDATE();



--if we make indexing in this table by CreatedDateTime column and we tring to get PeopleRegisteredTodayCount
--What is the best query we going to choose here?

-- First Query

SELECT PeopleRegisteredTodayCount=COUNT(*)
FROM People
WHERE CAST( CreatedDateTime as Date ) = CAST(GETDATE() as date)


-- Second Query

SELECT PeopleRegisteredTodayCount=COUNT(*)
FROM People
WHERE CreatedDateTime >= CAST(GETDATE() AS DATE)
AND CreatedDateTime < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))


SELECT PeopleRegisteredCountBetween=COUNT(*)
FROM People
WHERE CreatedDateTime >= CAST(@StartDate as Date)
AND CreatedDateTime < CAST(@EndDate as Date)



SELECT PeopleRegisteredCountByGendorBetween=COUNT(*)
FROM People
WHERE People.Gendor=@Gendor  and CreatedDateTime >= CAST(@StartDate as Date)


AND CreatedDateTime < CAST(@EndDate as Date);




                    SELECT PeopleCountByGender = COUNT(*)
                    FROM People
                    WHERE Gendor = 0;




select 
Applications.ApplicationID as [App ID],  
Applicant= People.FirstName+' '+ People.LastName,
ApplicationTypes.ApplicationTypeTitle as [Type],
case 
when Applications.ApplicationTypeID=1 then 'New'
when Applications.ApplicationTypeID = 1 then  'Canceled'
else 'Completed'
end as Status ,
cast (Applications.ApplicationDate as Date)as Date

from Applications
inner join People on Applications.ApplicantPersonID=People.PersonID
inner join applicationTypes on Applications.ApplicationTypeID=ApplicationTypes.ApplicationTypeID;


select TotalApplicationsCount =count(*) from Applications where Applications.ApplicationStatus=@Status



select * from UsersLogs

SELECT TOP 1 UsersLogs.LoginDateTime
                    FROM UsersLogs where UsersLogs.UserID=1
                    order by UsersLogs.LoginDateTime desc 




SELECT COUNT(*)
FROM dbo.Licenses
WHERE Licenses.ExpirationDate >=  Cast(@StartDate as date) and  Licenses.ExpirationDate < CAST(@EndDate as Date);


SELECT dbo.Countries.CountryName FROM dbo.Countries WHERE dbo.Countries.CountryID = 12

SELECT dbo.Drivers.DriverID,dbo.Drivers.PersonID,dbo.Drivers.CreatedByUserID,dbo.Drivers.CreatedDate
FROM dbo.Drivers
WHERE dbo.Drivers.PersonID = 1024;



SELECT TotalLicenseCount=COUNT(*)
FROM dbo.Licenses INNER JOIN dbo.Drivers ON dbo.Drivers.DriverID = dbo.Licenses.DriverID
WHERE Drivers.PersonID = @PersonID
AND dbo.Licenses.IsActive = @IsActive
and dbo.Licenses.IssueReason=@IssueReason;



select top 1  dbo.UsersLogs.UserLoginID,dbo.UsersLogs.UserID,dbo.UsersLogs.LoginDateTime,dbo.UsersLogs.LogoutDateTime from dbo.UsersLogs 
where dbo.UsersLogs.UserID=1
order by dbo.UsersLogs.LoginDateTime desc 




CREATE PROCEDURE SP_AddNewPerson
    @NationalNo NVARCHAR(50),
    @FirstName NVARCHAR(100),
    @SecondName NVARCHAR(100),
    @ThirdName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @DateOfBirth DATETIME,
    @Gendor BIT,
    @Address NVARCHAR(500),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @NationalityCountryID INT,
    @ImagePath NVARCHAR(250),
    @CreatedDateTime DATETIME,
    @NewPersonID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO People
    (
        NationalNo,
        FirstName,
        SecondName,
        ThirdName,
        LastName,
        DateOfBirth,
        Gendor,
        Address,
        Phone,
        Email,
        NationalityCountryID,
        ImagePath,
        CreatedDateTime
    )
    VALUES
    (
        @NationalNo,
        @FirstName,
        @SecondName,
        @ThirdName,
        @LastName,
        @DateOfBirth,
        @Gendor,
        @Address,
        @Phone,
        @Email,
        @NationalityCountryID,
        @ImagePath,
        @CreatedDateTime
    );

    SET @NewPersonID = SCOPE_IDENTITY();
END;


ALTER TABLE People
ADD CONSTRAINT UQ_Persons_NationalNo UNIQUE (NationalNo);




CREATE PROCEDURE SP_AddNewDriver
    @PersonID INT,
    @CreatedByUserID INT,
    @CreatedDate DATETIME,
    @NewDriverID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @NewDriverID = -1;

    IF NOT EXISTS (
        SELECT 1
        FROM Drivers
        WHERE PersonID = @PersonID
    )
    BEGIN
        INSERT INTO Drivers
        (
            PersonID,
            CreatedByUserID,
            CreatedDate
        )
        VALUES
        (
            @PersonID,
            @CreatedByUserID,
            @CreatedDate
        );

        SET @NewDriverID = SCOPE_IDENTITY();
    END
END;




CREATE PROCEDURE SP_CheckDriverExists
    @PersonID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Drivers
        WHERE PersonID = @PersonID
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;


CREATE PROCEDURE SP_AddNewDriver
    @PersonID INT,
    @CreatedByUserID INT,
    @CreatedDate DATETIME,
    @NewDriverID INT OUTPUT
AS
BEGIN
    DECLARE @Result INT;

    SET @NewDriverID = -1;

    EXEC @Result = SP_CheckDriverExists
        @PersonID = @PersonID;

    IF @Result = 0
    BEGIN
        INSERT INTO Drivers
        (
            PersonID,
            CreatedByUserID,
            CreatedDate
        )
        VALUES
        (
            @PersonID,
            @CreatedByUserID,
            @CreatedDate
        );

        SET @NewDriverID = SCOPE_IDENTITY();
    END
END;




CREATE PROCEDURE SP_CheckUserExists
    @PersonID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE PersonID = @PersonID
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;


CREATE PROCEDURE SP_AddNewUser
    @PersonID INT,
    @UserName NVARCHAR(50),
    @Password NVARCHAR(255),
    @IsActive BIT,
    @IsLocked BIT,
    @NewUserID INT OUTPUT
AS
BEGIN
    DECLARE @Result INT;

    SET @NewUserID = -1;

    EXEC @Result = SP_CheckUserExists
        @PersonID = @PersonID;

    IF @Result = 0
    BEGIN
        INSERT INTO Users
        (
            PersonID,
            UserName,
            Password,
            IsActive,
            IsLocked
        )
        VALUES
        (
            @PersonID,
            @UserName,
            @Password,
            @IsActive,
            @IsLocked
        );

        SET @NewUserID = SCOPE_IDENTITY();
    END
END;

CREATE PROCEDURE SP_AddNewApplication
    @ApplicationPersonID INT,
    @ApplicationDate DATETIME,
    @ApplicationTypeID INT,
    @ApplicationStatus TINYINT,
    @LastStatusDate DATETIME,
    @PaidFees REAL,
    @CreatedByUserID INT,
    @NewApplicationID INT OUTPUT
AS
BEGIN
    INSERT INTO Applications
    (
        ApplicantPersonID,
        ApplicationDate,
        ApplicationTypeID,
        ApplicationStatus,
        LastStatusDate,
        PaidFees,
        CreatedByUserID
    )
    VALUES
    (
        @ApplicationPersonID,
        @ApplicationDate,
        @ApplicationTypeID,
        @ApplicationStatus,
        @LastStatusDate,
        @PaidFees,
        @CreatedByUserID
    );

    SET @NewApplicationID = SCOPE_IDENTITY();
END;


CREATE PROCEDURE SP_AddNewApplicationType
    @Title NVARCHAR(100),
    @Fees REAL,
    @NewApplicationTypeID INT OUTPUT
AS
BEGIN
    INSERT INTO ApplicationTypes
    (
        ApplicationTypeTitle,
        ApplicationFees
    )
    VALUES
    (
        @Title,
        @Fees
    );

    SET @NewApplicationTypeID = SCOPE_IDENTITY();
END;


CREATE PROCEDURE SP_AddNewDetainedLicense
    @LicenseID INT,
    @DetainDate DATETIME,
    @FineFees REAL,
    @CreatedByUserID INT,
    @IsReleased BIT,
    @ReleaseDate DATETIME = NULL,
    @ReleasedByUserID INT = NULL,
    @ReleaseApplicationID INT = NULL,
    @LastActionDateTime DATETIME,
    @DetainReasonID INT,
    @NewDetainID INT OUTPUT
AS
BEGIN
    INSERT INTO dbo.DetainedLicenses
    (
        LicenseID,
        DetainDate,
        FineFees,
        CreatedByUserID,
        IsReleased,
        ReleaseDate,
        ReleasedByUserID,
        ReleaseApplicationID,
        LastActionDateTime,
        DetainReasonID
    )
    VALUES
    (
        @LicenseID,
        @DetainDate,
        @FineFees,
        @CreatedByUserID,
        @IsReleased,
        @ReleaseDate,
        @ReleasedByUserID,
        @ReleaseApplicationID,
        @LastActionDateTime,
        @DetainReasonID
    );

    SET @NewDetainID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE SP_AddNewDetainReason
    @ReasonText NVARCHAR(500),
    @NewDetainReasonID INT OUTPUT
AS
BEGIN
    INSERT INTO dbo.DetainReasons (ReasonText)
    VALUES (@ReasonText);

    SET @NewDetainReasonID = SCOPE_IDENTITY();
END;



CREATE PROCEDURE SP_AddNewInternationalLicense
    @ApplicationID INT,
    @DriverID INT,
    @IssuedUsingLocalLicenseID INT,
    @IssueDate DATETIME,
    @ExpirationDate DATETIME,
    @IsActive BIT,
    @CreatedByUserID INT,
    @NewInternationalLicenseID INT OUTPUT
AS
BEGIN
    UPDATE InternationalLicenses
    SET IsActive = 0
    WHERE DriverID = @DriverID;

    INSERT INTO InternationalLicenses
    (
        ApplicationID,
        DriverID,
        IssuedUsingLocalLicenseID,
        IssueDate,
        ExpirationDate,
        IsActive,
        CreatedByUserID
    )
    VALUES
    (
        @ApplicationID,
        @DriverID,
        @IssuedUsingLocalLicenseID,
        @IssueDate,
        @ExpirationDate,
        @IsActive,
        @CreatedByUserID
    );

    SET @NewInternationalLicenseID = SCOPE_IDENTITY();
END;



CREATE PROCEDURE SP_AddNewLicense
    @ApplicationID INT,
    @DriverID INT,
    @LicenseClassID INT,
    @IssueDate DATETIME,
    @ExpirationDate DATETIME,
    @Notes NVARCHAR(500),
    @PaidFees REAL,
    @IsActive BIT,
    @IssueReason TINYINT,
    @CreatedByUserID INT,
    @NewLicenseID INT OUTPUT
AS
BEGIN
    INSERT INTO dbo.Licenses
    (
        ApplicationID,
        DriverID,
        LicenseClassID,
        IssueDate,
        ExpirationDate,
        Notes,
        PaidFees,
        IsActive,
        IssueReason,
        CreatedByUserID
    )
    VALUES
    (
        @ApplicationID,
        @DriverID,
        @LicenseClassID,
        @IssueDate,
        @ExpirationDate,
        @Notes,
        @PaidFees,
        @IsActive,
        @IssueReason,
        @CreatedByUserID
    );

    SET @NewLicenseID = SCOPE_IDENTITY();
END;


CREATE PROCEDURE SP_AddNewLicenseClass
    @ClassName NVARCHAR(100),
    @ClassDescription NVARCHAR(500),
    @MinimumAllowedAge TINYINT,
    @DefaultValidityLength TINYINT,
    @ClassFees smallmoney,
    @NewLicenseClassID INT OUTPUT
AS
BEGIN
    INSERT INTO LicenseClasses
    (
        ClassName,
        ClassDescription,
        MinimumAllowedAge,
        DefaultValidityLength,
        ClassFees
    )
    VALUES
    (
        @ClassName,
        @ClassDescription,
        @MinimumAllowedAge,
        @DefaultValidityLength,
        @ClassFees
    );

    SET @NewLicenseClassID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE SP_AddNewLocalDrivingLicenseApplication
    @ApplicationID INT,
    @LicenseClassID INT,
    @NewLocalDrivingLicenseApplicationID INT OUTPUT
AS
BEGIN
    INSERT INTO LocalDrivingLicenseApplications
    (
        ApplicationID,
        LicenseClassID
    )
    VALUES
    (
        @ApplicationID,
        @LicenseClassID
    );

    SET @NewLocalDrivingLicenseApplicationID = SCOPE_IDENTITY();
END;



CREATE PROCEDURE SP_AddNewLocking
    @UserID INT,
    @LockedDateTime DATETIME,
    @UnlockedDateTime DATETIME = NULL,
    @NewLockedUserAccountID INT OUTPUT
AS
BEGIN
    INSERT INTO Lockings
    (
        UserID,
        LockedDateTime,
        UnlockedDateTime
    )
    VALUES
    (
        @UserID,
        @LockedDateTime,
        @UnlockedDateTime
    );

    SET @NewLockedUserAccountID = SCOPE_IDENTITY();
END;



CREATE PROCEDURE SP_AddNewPasswordHistory
    @UserID INT,
    @PasswordChange DATETIME,
    @Password NVARCHAR(255),
    @NewPasswordHistoryID INT OUTPUT
AS
BEGIN
    INSERT INTO PasswordsHistory
    (
        UserID,
        PasswordChange,
        Password
    )
    VALUES
    (
        @UserID,
        @PasswordChange,
        @Password
    );

    SET @NewPasswordHistoryID = SCOPE_IDENTITY();
END;



CREATE PROCEDURE SP_CheckRoleExists
    @RoleName NVARCHAR(250)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Roles
        WHERE RoleName = @RoleName
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;


CREATE PROCEDURE SP_AddNewRole
    @RoleName NVARCHAR(250),
    @Permissions BIGINT,
    @Description NVARCHAR(500),
    @NewRoleID INT OUTPUT
AS
BEGIN
    DECLARE @Result INT;

    SET @NewRoleID = -1;

    EXEC @Result = SP_CheckRoleExists
        @RoleName = @RoleName;

    IF @Result = 0
    BEGIN
        INSERT INTO Roles
        (
            RoleName,
            Permissions,
            Description
        )
        VALUES
        (
            @RoleName,
            @Permissions,
            @Description
        );

        SET @NewRoleID = SCOPE_IDENTITY();
    END
END;


CREATE PROCEDURE SP_AddNewTestAppointment
    @TestTypeID INT,
    @LocalDrivingLicenseApplicationID INT,
    @AppointmentDate DATETIME,
    @PaidFees smallmoney,
    @CreatedByUserID INT,
    @IsLocked BIT,
    @RetakeTestApplicationID INT = NULL,
    @NewTestAppointmentID INT OUTPUT
AS
BEGIN
    INSERT INTO TestAppointments
    (
        TestTypeID,
        LocalDrivingLicenseApplicationID,
        AppointmentDate,
        PaidFees,
        CreatedByUserID,
        IsLocked,
        RetakeTestApplicationID
    )
    VALUES
    (
        @TestTypeID,
        @LocalDrivingLicenseApplicationID,
        @AppointmentDate,
        @PaidFees,
        @CreatedByUserID,
        @IsLocked,
        @RetakeTestApplicationID
    );

    SET @NewTestAppointmentID = SCOPE_IDENTITY();
END;


CREATE PROCEDURE SP_AddNewTest
    @TestAppointmentID INT,
    @TestResult BIT,
    @Notes NVARCHAR(500),
    @CreatedByUserID INT,
    @NewTestID INT OUTPUT
AS
BEGIN
    INSERT INTO Tests
    (
        TestAppointmentID,
        TestResult,
        Notes,
        CreatedByUserID
    )
    VALUES
    (
        @TestAppointmentID,
        @TestResult,
        @Notes,
        @CreatedByUserID
    );

    SET @NewTestID = SCOPE_IDENTITY();

    UPDATE dbo.TestAppointments
    SET IsLocked = 1
    WHERE TestAppointmentID = @TestAppointmentID;
END;




CREATE PROCEDURE SP_AddNewUserLog
    @UserID INT,
    @LoginDateTime DATETIME,
    @LogoutDateTime DATETIME = NULL,
    @NewUserLoginID INT OUTPUT
AS
BEGIN
    INSERT INTO UsersLogs
    (
        UserID,
        LoginDateTime,
        LogoutDateTime
    )
    VALUES
    (
        @UserID,
        @LoginDateTime,
        @LogoutDateTime
    );

    SET @NewUserLoginID = SCOPE_IDENTITY();
END;

CREATE PROCEDURE SP_IsUserPermissionsExist
    @UserID INT
AS
BEGIN
    SELECT 1 
    FROM UserPermissions
    WHERE UserID = @UserID;
END
GO

CREATE PROCEDURE SP_CheckUserPermissionsExists
    @UserID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM UserPermissions
        WHERE UserID = @UserID
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;

CREATE PROCEDURE SP_AddNewUserPermissions
    @UserID INT,
    @Permissions BIGINT,
    @NewUserPermissionsID INT OUTPUT
AS
BEGIN
    DECLARE @Result INT;

    SET @NewUserPermissionsID = -1;

    EXEC @Result = SP_CheckUserPermissionsExists
        @UserID = @UserID;

    IF @Result = 0
    BEGIN
        INSERT INTO UserPermissions
        (
            UserID,
            Permissions
        )
        VALUES
        (
            @UserID,
            @Permissions
        );

        SET @NewUserPermissionsID = SCOPE_IDENTITY();
    END
END;


CREATE PROCEDURE SP_CheckPersonExists
    @NationalNo NVARCHAR(50)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM People
        WHERE NationalNo = @NationalNo
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;


CREATE PROCEDURE SP_CheckApplicationExists
    @ApplicationID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Applications
        WHERE ApplicationID = @ApplicationID
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;

CREATE PROCEDURE SP_CheckApplicationTypeExists
    @ApplicationTypeTitle NVARCHAR(250)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM ApplicationTypes
        WHERE ApplicationTypeTitle = @ApplicationTypeTitle
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;
GO



CREATE PROCEDURE SP_CheckCountryExistsByID
    @CountryID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Countries
        WHERE CountryID = @CountryID
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;
GO

CREATE PROCEDURE SP_CheckCountryExistsByName
    @CountryName NVARCHAR(100)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Countries
        WHERE CountryName = @CountryName
    )
        RETURN 1;
    ELSE
        RETURN 0;
END;
GO

CREATE PROCEDURE SP_CheckApplicationTypeExistsByID
    @ApplicationTypeID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM ApplicationTypes
        WHERE ApplicationTypeID = @ApplicationTypeID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO


CREATE PROCEDURE SP_CheckLicenseDetained
    @LicenseID INT,
    @IsReleased BIT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.DetainedLicenses
        WHERE LicenseID = @LicenseID
          AND IsReleased = @IsReleased
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckDriverExistsByID
    @DriverID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Drivers
        WHERE DriverID = @DriverID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO
CREATE PROCEDURE SP_CheckDriverExistsByPersonID
    @PersonID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Drivers
        WHERE PersonID = @PersonID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;


CREATE PROCEDURE SP_CheckInternationalLicenseExists
    @InternationalLicenseID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM InternationalLicenses
        WHERE InternationalLicenseID = @InternationalLicenseID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckInternationalLicenseExistsByOrdinaryLicenseID
    @OrdinaryLicenseID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.InternationalLicenses
        WHERE IssuedUsingLocalLicenseID = @OrdinaryLicenseID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckActiveInternationalLicenseExists
    @OrdinaryLicenseID INT,
    @LicenseClassID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.InternationalLicenses
        INNER JOIN dbo.Licenses
            ON dbo.Licenses.LicenseID =
               dbo.InternationalLicenses.IssuedUsingLocalLicenseID
        WHERE dbo.InternationalLicenses.IsActive = 1
          AND dbo.InternationalLicenses.IssuedUsingLocalLicenseID =
              @OrdinaryLicenseID
          AND dbo.Licenses.LicenseClassID = @LicenseClassID
          AND dbo.InternationalLicenses.ExpirationDate > GETDATE()
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckActiveLicenseExistsByLicenseIDAndClassID
    @LicenseID INT,
    @LicenseClassID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.Licenses
        WHERE IsActive = 1
          AND LicenseID = @LicenseID
          AND LicenseClassID = @LicenseClassID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckExpiredLicenseByLicenseID
    @LicenseID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.Licenses
        WHERE LicenseID = @LicenseID
          AND ExpirationDate < GETDATE()
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckIssueLicenseReason
    @LicenseID INT,
    @IssueLicenseReason TINYINT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.Licenses
        WHERE IsActive = 1
          AND LicenseID = @LicenseID
          AND IssueReason = @IssueLicenseReason
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckLicenseIssuedForReplacement
    @LicenseID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.Licenses
        WHERE IsActive = 1
          AND LicenseID = @LicenseID
          AND IssueReason IN (3, 4)
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckLicenseClassExistsByID
    @LicenseClassID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM LicenseClasses
        WHERE LicenseClassID = @LicenseClassID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckLicenseClassExistsByName
    @ClassName NVARCHAR(100)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM LicenseClasses
        WHERE ClassName = @ClassName
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckLocalDrivingLicenseApplicationExists
    @LocalDrivingLicenseApplicationID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM LocalDrivingLicenseApplications
        WHERE LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckMinimumAgeRequirement
    @PersonID INT,
    @LicenseClassID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM LocalDrivingLicenseApplications
        INNER JOIN Applications
            ON LocalDrivingLicenseApplications.ApplicationID =
               Applications.ApplicationID
        INNER JOIN LicenseClasses
            ON LocalDrivingLicenseApplications.LicenseClassID =
               LicenseClasses.LicenseClassID
        INNER JOIN People
            ON Applications.ApplicantPersonID = People.PersonID
        WHERE People.PersonID = @PersonID
          AND LicenseClasses.LicenseClassID = @LicenseClassID
          AND YEAR(GETDATE()) - YEAR(People.DateOfBirth)
              >= LicenseClasses.MinimumAllowedAge
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckActiveScheduledTest
    @LocalDrivingLicenseApplicationID INT,
    @TestTypeID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM LocalDrivingLicenseApplications
        INNER JOIN TestAppointments
            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
               TestAppointments.LocalDrivingLicenseApplicationID
        WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND TestAppointments.TestTypeID = @TestTypeID
          AND TestAppointments.IsLocked = 0
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckUserCurrentlyLocked
    @UserID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Lockings
        WHERE UserID = @UserID
          AND UnlockedDateTime IS NULL
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckPasswordInHistory
    @UserID INT,
    @Password NVARCHAR(100)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM PasswordsHistory
        WHERE UserID = @UserID
          AND Password = @Password
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckImageBelongsToOtherPerson
    @ImagePath NVARCHAR(500),
    @PersonID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM People
        WHERE ImagePath = @ImagePath
          AND PersonID <> @PersonID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO


CREATE PROCEDURE SP_CheckTestAppointmentExists
    @TestAppointmentID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM TestAppointments
        WHERE TestAppointmentID = @TestAppointmentID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckHasActiveAppointment
    @LocalDrivingLicenseApplicationID INT,
    @TestTypeID INT,
    @LicenseClassID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.TestAppointments
        INNER JOIN dbo.LocalDrivingLicenseApplications
            ON dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
               dbo.TestAppointments.LocalDrivingLicenseApplicationID
        WHERE dbo.TestAppointments.LocalDrivingLicenseApplicationID =
              @LocalDrivingLicenseApplicationID
          AND dbo.TestAppointments.TestTypeID = @TestTypeID
          AND dbo.TestAppointments.IsLocked = 0
          AND dbo.LocalDrivingLicenseApplications.LicenseClassID =
              @LicenseClassID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckLockedAppointment
    @TestAppointmentID INT
AS
BEGIN
    SELECT IsLocked
    FROM TestAppointments
    WHERE TestAppointmentID = @TestAppointmentID;
END;
GO
 --__________________________________

 CREATE PROCEDURE SP_CheckTestExistsByID
    @TestID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Tests
        WHERE TestID = @TestID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckTestExistsByTestAppointmentID
    @TestAppointmentID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Tests
        WHERE TestAppointmentID = @TestAppointmentID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckTestExistsByPersonID
    @PersonID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.Tests
        INNER JOIN dbo.TestAppointments
            ON dbo.TestAppointments.TestAppointmentID =
               dbo.Tests.TestAppointmentID
        INNER JOIN dbo.LocalDrivingLicenseApplications
            ON dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
               dbo.TestAppointments.LocalDrivingLicenseApplicationID
        INNER JOIN dbo.Applications
            ON dbo.Applications.ApplicationID =
               dbo.LocalDrivingLicenseApplications.ApplicationID
        WHERE dbo.Applications.ApplicantPersonID = @PersonID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckTestExistsByPersonTestTypeAndLicenseClass
    @PersonID INT,
    @TestTypeID INT,
    @LicenseClassID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM dbo.Tests
        INNER JOIN dbo.TestAppointments
            ON dbo.TestAppointments.TestAppointmentID =
               dbo.Tests.TestAppointmentID
        INNER JOIN dbo.LocalDrivingLicenseApplications
            ON dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =
               dbo.TestAppointments.LocalDrivingLicenseApplicationID
        INNER JOIN dbo.Applications
            ON dbo.Applications.ApplicationID =
               dbo.LocalDrivingLicenseApplications.ApplicationID
        WHERE dbo.Applications.ApplicantPersonID = @PersonID
          AND dbo.TestAppointments.TestTypeID = @TestTypeID
          AND dbo.LocalDrivingLicenseApplications.LicenseClassID =
              @LicenseClassID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckTestTypeExistsByID
    @TestTypeID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM TestTypes
        WHERE TestTypeID = @TestTypeID
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckTestTypeExistsByTitle
    @TestTypeTitle NVARCHAR(100)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM TestTypes
        WHERE TestTypeTitle = @TestTypeTitle
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO


CREATE PROCEDURE SP_CheckUserExistsByID
    @UserID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE UserID = @UserID
          AND MarkForDelete = 0
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckUserExistsByUserName
    @UserName NVARCHAR(100)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE UserName = @UserName
          AND MarkForDelete = 0
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckUserExistsByPersonID
    @PersonId INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE PersonId = @PersonId
          AND MarkForDelete = 0
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO


CREATE PROCEDURE SP_CheckUserActiveByID
    @UserID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE UserID = @UserID
          AND IsActive = 1
          AND MarkForDelete = 0
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO

CREATE PROCEDURE SP_CheckUserActiveByUserName
    @UserName NVARCHAR(100)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Users
        WHERE UserName = @UserName
          AND IsActive = 1
          AND MarkForDelete = 0
    )
        SELECT 1;
    ELSE
        SELECT 0;
END;
GO



select UserLoginID as [User Login ID] ,
Users.UserName  ,
userslogs.LoginDateTime as [Login Date & Time],
userslogs.LogoutDateTime as [Logout Date & Time],
[Durration Session] = LogoutDateTime - LoginDateTime
from userslogs inner join Users  on USERS.UserID = UsersLogs.UserID;



SELECT
               PersonID,
               NationalNo,
               FirstName,
               SecondName,
               ThirdName,
               LastName,
              DateOfBirth= cast(DateOfBirth as date),
               Gendor =
                   CASE
                       WHEN People.Gendor = 0 THEN 'Male'
                       ELSE 'Female'
                   END,
               Address,
               Phone,
               Email,
               Countries.CountryID,
               Countries.CountryName,
               People.ImagePath
           FROM People
           INNER JOIN Countries
               ON Countries.CountryID = People.NationalityCountryID
           ORDER BY People.FirstName



                      SELECT dbo.LicenseClasses.LicenseClassID ,dbo.LicenseClasses.ClassName,
                      dbo.LicenseClasses.ClassDescription,
                      dbo.LicenseClasses.ClassDescription,dbo.LicenseClasses.ClassFees,dbo.LicenseClasses.DefaultValidityLength
           FROM DBO.LicenseClasses





       SELECT
            InternationalLicenseID,
            ApplicationID,
            DriverID,
            IssuedUsingLocalLicenseID,
            IssueDate = cast( IssueDate as date) ,
            ExpirationDate = cast(ExpirationDate as date) ,
            IsActive
        FROM InternationalLicenses
        ORDER BY IsActive, ExpirationDate DESC



ALTER DATABASE DVLD
MODIFY FILE (
    NAME = YourLogicalFileName,
    FILENAME = 'C:\DVLD_Project_Solution\DVLD_Project\DVLD_Data_Base\DataBaseFiles\DVLD.mdf'
);


BACKUP DATABASE [DVLD]
TO DISK = 'C:\DVLD_Project_Solution\DVLD_Project\DVLD_Data_Base\DVLD.bak'
WITH INIT;



SELECT name, physical_name
FROM sys.master_files
WHERE database_id = DB_ID('DVLD');




USE master;
GO

ALTER DATABASE [DVLD]
MODIFY FILE (
    NAME = 'DVLD',
    FILENAME = 'C:\DVLD_Project_Solution\DVLD_Project\DVLD_Data_Base\DataBaseFiles\DVLD.mdf'
);
GO

ALTER DATABASE [DVLD]
MODIFY FILE (
    NAME = 'DVLD_log',
    FILENAME = 'C:\DVLD_Project_Solution\DVLD_Project\DVLD_Data_Base\DataBaseFiles\DVLD_log.ldf'
);
GO



USE master;
GO

SELECT name, physical_name, state_desc
FROM sys.master_files
WHERE database_id = DB_ID('DVLD');



USE master;
GO

ALTER DATABASE [DVLD] SET ONLINE;
GO


select * from people

use DVLD

                SELECT
                    DetainID as [Detain ID],
                    LicenseID as [License ID],
                    [Detain Date] = cast(DetainDate as date),
                    FineFees as [Fine Fees] ,
                    CreatedByUserID as [Created By UserID],
                    IsReleased as [Is Released],
                    [Release Date] =  cast(ReleaseDate as date),
                    ReleasedByUserID as [Released By UserID],
                    ReleaseApplicationID as [Release Application ID] ,
                    LastActionDateTime as [Last Action DateTime],
                    DetainReasonID as [Detain Reason ID]
                FROM dbo.DetainedLicenses



        select DetainID as [Detain ID] from  DetainedLicenses




         SELECT TOP 5
        DetainID,
        IsReleased,
        dbo.DetainReasons.ReasonText,
        DetainDate,
        ReleaseDate,
        LastActionDateTime
    FROM dbo.DetainedLicenses
    INNER JOIN dbo.DetainReasons
        ON dbo.DetainReasons.DetainReasonID =
           dbo.DetainedLicenses.DetainReasonID
    ORDER BY dbo.DetainedLicenses.LastActionDateTime DESC;


                    SELECT
                    DetainID as [Detain ID],
                    LicenseID as [License ID],
                    [Detain Date] = cast(DetainDate as date),
                    FineFees as [Fine Fees] ,
                    CreatedByUserID as [Created By UserID],
                    IsReleased as [Is Released],
                    [Release Date] =  cast(ReleaseDate as date),
                    ReleasedByUserID as [Released By UserID],
                    ReleaseApplicationID as [Release Application ID] ,
                    LastActionDateTime as [Last Action DateTime],
                    DetainReasonID as [Detain Reason ID]
                FROM dbo.DetainedLicenses;




select 
                    DetainID as [Detain ID],
                    LicenseID as [License ID],
                    [Detain Date] = cast(DetainDate as date),
                      IsReleased as [Is Released],
                                          FineFees as [Fine Fees] ,
                    [Release Date] =  cast(ReleaseDate as date),
                   NationalNo as [National No]  ,
                   FullName as [Full Name],
                   ReleaseApplicationID as [Release Application ID]

from DetainedLicenses_View



                SELECT 
                    CurrentUser.UserID AS [User ID],

                    [Full Name] =
                        People.FirstName + ' ' +
                        ISNULL(People.SecondName, '') +
                        ISNULL(People.ThirdName, '') + ' ' +
                        People.LastName,

                    CurrentUser.UserName AS [User Name],

                    Roles.RoleName AS [Role Name],

                    [Is Active] =
                        CASE
                            WHEN CurrentUser.IsActive = 1
                                THEN 'Active'
                            ELSE 'Inactive'
                        END,

                    (
                        SELECT TOP 1
                            UsersLogs.LoginDateTime
                        FROM UsersLogs
                        WHERE UsersLogs.UserID = CurrentUser.UserID
                        ORDER BY UsersLogs.LoginDateTime DESC
                    ) AS [Last Login]

                FROM Users AS CurrentUser

                INNER JOIN People
                    ON People.PersonID = CurrentUser.PersonID

                INNER JOIN Roles
                    ON Roles.RoleID = CurrentUser.RoleID;




select found = 1 from TestAppointments where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;
inner join 


 begin try

    DELETE FROM LocalDrivingLicenseApplications
    WHERE LocalDrivingLicenseApplicationID = 38

    end try 
    begin catch
        throw
        

    end catch



    exec sp_helptext 'SP_CheckMinimumAgeRequirement'


alter PROCEDURE SP_IsTestAppointmentExists   @LocalDrivingLicenseApplicationID INT  ,@LicenseClassID int
AS  
BEGIN  
    IF EXISTS (  
        SELECT 1  
        FROM TestAppointments  
        inner join LocalDrivingLicenseApplications on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
        WHERE  TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID   and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
    )  
        SELECT 1;  
    ELSE  
        SELECT 0;  
END;  



  
CREATE PROCEDURE SP_CheckMinimumAgeRequirement  
    @PersonID INT,  
    @LicenseClassID INT  
AS  
BEGIN  
    IF EXISTS (  
        SELECT 1  
        FROM LocalDrivingLicenseApplications  
        INNER JOIN Applications    ON LocalDrivingLicenseApplications.ApplicationID =   Applications.ApplicationID   
        INNER JOIN LicenseClasses    ON LocalDrivingLicenseApplications.LicenseClassID =    LicenseClasses.LicenseClassID  
        INNER JOIN People    ON Applications.ApplicantPersonID = People.PersonID  
      
      WHERE People.PersonID = @PersonID  AND LicenseClasses.LicenseClassID = @LicenseClassID   AND YEAR(GETDATE()) - YEAR(People.DateOfBirth)  >= LicenseClasses.MinimumAllowedAge  
    )  
        SELECT 1;  
    ELSE  
        SELECT 0;  
END;  


   SELECT 1  

        FROM people  
        INNER JOIN Applications    ON LocalDrivingLicenseApplications.ApplicationID =   Applications.ApplicationID   
        INNER JOIN LicenseClasses    ON LocalDrivingLicenseApplications.LicenseClassID =    LicenseClasses.LicenseClassID  
        INNER JOIN People    ON Applications.ApplicantPersonID = People.PersonID  
      
      WHERE People.PersonID = 1  AND LicenseClasses.LicenseClassID = 3   AND ((YEAR(GETDATE()) - YEAR(People.DateOfBirth))  >= LicenseClasses.MinimumAllowedAge  )
    



    select * from LocalDrivingLicenseApplications_View

    select * from people
    select * from LicenseClasses


    
    select MinimumAllowedAge from LicenseClasses where LicenseClassID = 3

    select 1 from 
    (
    select  
    PersonAge=  YEAR(GETDATE()) - YEAR(People.DateOfBirth)  ,     
    MinimaumAllowedAge =  (  select MinimumAllowedAge from LicenseClasses where LicenseClassID = 3)

from people where  personID=1)R1 where R1.PersonAge >= R1.MinimaumAllowedAge



ALTER PROCEDURE SP_CheckMinimumAgeRequirement  
    @PersonID INT,  
    @LicenseClassID INT  
AS  
BEGIN  
    IF EXISTS 
    (  
                
    select 1 from 
    (
        select  
        PersonAge=  YEAR(GETDATE()) - YEAR(People.DateOfBirth)  ,     
        MinimaumAllowedAge =  (  select MinimumAllowedAge from LicenseClasses where LicenseClassID = @LicenseClassID)

            from people where  personID = @PersonID)R1 where R1.PersonAge >= R1.MinimaumAllowedAge
    )  
        RETURN 1;  
    ELSE  
        RETURN 0;  
END;  



exec sp_helptext 'SP_CheckDriverExists'

declare @result int; 

  exec @result =   SP_CheckMinimumAgeRequirement @PersonID = 1 ,@LicenseClassID = 3

  if(@result =1 )
        PRINT 'person can acces'
        else
        print 'no minimaum age requirment'



          
alter PROCEDURE SP_CheckMinimumAgeRequirement    
    @PersonID INT,    
    @LicenseClassID INT    
AS    
BEGIN    
    IF EXISTS   
    (    
                  
    select 1 from   
    (  
        select    
        PersonAge=  YEAR(GETDATE()) - YEAR(People.DateOfBirth)  ,       
        MinimaumAllowedAge =  (  select MinimumAllowedAge from LicenseClasses where LicenseClassID = @LicenseClassID)  
  
            from people where  personID = @PersonID)R1 where R1.PersonAge >= R1.MinimaumAllowedAge  
    )    
        return 1;    
    ELSE    
        return 0;    
END;    
  

  select * from licenses

  select * from 

                          SELECT DetainRea  sonID, ReasonText
                        FROM dbo.DetainReasons;



EXEC SP_CheckLicenseDetained @LicenseID = 23, @IsReleased =0  


exec sp_helptext 'SP_CheckLicenseDetained'

alter PROCEDURE SP_CheckLicenseDetained  
    @LicenseID INT,  
    @IsReleased BIT  
AS  
BEGIN  
    IF EXISTS (  
        SELECT 1  
        FROM dbo.DetainedLicenses  
        WHERE LicenseID = @LicenseID  
          AND IsReleased = @IsReleased  
    )  
        return 1;  
    ELSE  
        return 0;  
END;  



                        SELECT DetainReasonID, ReasonText
                        FROM dbo.DetainReasons
                        WHERE ReasonText = @ReasonText;


select * from Licenses



            SELECT COUNT(*)
            FROM Licenses
            WHERE Licenses.IsActive = 1 and (GETDATE()>Licenses.ExpirationDate)




select * from people



INSERT INTO people
(
    NationalNo, FirstName, SecondName, ThirdName,
    LastName, DateOfBirth, Gendor, Address, Phone,
    Email, NationalityCountryID, ImagePath, CreatedDateTime
)
VALUES
('US100001', 'James', 'William', 'Robert', 'Smith', '1990-05-12', 1, 'New York, USA', '+12125550101', 'james.smith@example.com', 1, NULL, GETDATE()),
('US100002', 'Emily', 'Rose', NULL, 'Johnson', '1995-08-23', 0, 'Los Angeles, USA', '+12135550102', 'emily.johnson@example.com', 1, NULL, GETDATE()),
('US100003', 'Michael', 'David', 'John', 'Brown', '1988-02-14', 1, 'Chicago, USA', '+13125550103', 'michael.brown@example.com', 1, NULL, GETDATE()),
('US100004', 'Olivia', 'Grace', NULL, 'Davis', '1998-11-09', 0, 'Boston, USA', '+16175550104', 'olivia.davis@example.com', 1, NULL, GETDATE()),
('US100005', 'William', 'James', 'Thomas', 'Wilson', '1985-04-30', 1, 'Houston, USA', '+17135550105', 'william.wilson@example.com', 1, NULL, GETDATE()),

('UK100006', 'Oliver', 'George', NULL, 'Taylor', '1992-06-18', 1, 'London, UK', '+44205550106', 'oliver.taylor@example.com', 2, NULL, GETDATE()),
('UK100007', 'Charlotte', 'Anne', 'Marie', 'Thomas', '1997-03-25', 0, 'Manchester, UK', '+441615550107', 'charlotte.thomas@example.com', 2, NULL, GETDATE()),
('UK100008', 'Harry', 'Edward', NULL, 'Walker', '1991-09-11', 1, 'Liverpool, UK', '+441515550108', 'harry.walker@example.com', 2, NULL, GETDATE()),
('UK100009', 'Amelia', 'Jane', 'Rose', 'White', '1999-12-05', 0, 'Birmingham, UK', '+441215550109', 'amelia.white@example.com', 2, NULL, GETDATE()),
('UK100010', 'George', 'Henry', NULL, 'Harris', '1987-07-20', 1, 'Bristol, UK', '+441175550110', 'george.harris@example.com', 2, NULL, GETDATE()),

('CA100011', 'Noah', 'Alexander', NULL, 'Martin', '1993-01-15', 1, 'Toronto, Canada', '+14165550111', 'noah.martin@example.com', 3, NULL, GETDATE()),
('CA100012', 'Sophia', 'Elizabeth', 'Grace', 'Clark', '1996-10-22', 0, 'Vancouver, Canada', '+16045550112', 'sophia.clark@example.com', 3, NULL, GETDATE()),
('CA100013', 'Lucas', 'Benjamin', NULL, 'Lewis', '1989-04-08', 1, 'Ottawa, Canada', '+16135550113', 'lucas.lewis@example.com', 3, NULL, GETDATE()),
('CA100014', 'Mia', 'Victoria', NULL, 'Robinson', '2000-02-17', 0, 'Calgary, Canada', '+14035550114', 'mia.robinson@example.com', 3, NULL, GETDATE()),
('CA100015', 'Ethan', 'Christopher', 'James', 'Hall', '1986-08-29', 1, 'Montreal, Canada', '+15145550115', 'ethan.hall@example.com', 3, NULL, GETDATE()),

('AU100016', 'Jack', 'Thomas', NULL, 'Young', '1994-03-12', 1, 'Sydney, Australia', '+61255550116', 'jack.young@example.com', 4, NULL, GETDATE()),
('AU100017', 'Isabella', 'Charlotte', 'Rose', 'King', '1998-06-07', 0, 'Melbourne, Australia', '+61355550117', 'isabella.king@example.com', 4, NULL, GETDATE()),
('AU100018', 'Charlie', 'Edward', NULL, 'Wright', '1990-12-19', 1, 'Brisbane, Australia', '+61755550118', 'charlie.wright@example.com', 4, NULL, GETDATE()),
('AU100019', 'Ava', 'Madison', NULL, 'Green', '1997-05-26', 0, 'Perth, Australia', '+61855550119', 'ava.green@example.com', 4, NULL, GETDATE()),
('AU100020', 'Thomas', 'Joseph', 'David', 'Baker', '1984-09-03', 1, 'Adelaide, Australia', '+61855550120', 'thomas.baker@example.com', 4, NULL, GETDATE());


INSERT INTO people
(
    NationalNo, FirstName, SecondName, ThirdName,
    LastName, DateOfBirth, Gendor, Address, Phone,
    Email, NationalityCountryID, ImagePath, CreatedDateTime
)
VALUES
('US100031','Andrew','Michael',NULL,'Miller','1991-03-14',1,'Phoenix, USA','+16025550131','andrew.miller@example.com',1,NULL,GETDATE()),
('US100032','Hannah','Elizabeth','Rose','Anderson','1996-07-22',0,'Dallas, USA','+12145550132','hannah.anderson@example.com',1,NULL,GETDATE()),
('US100033','Christopher','James',NULL,'Thomas','1989-11-05',1,'San Diego, USA','+16195550133','christopher.thomas@example.com',1,NULL,GETDATE()),
('US100034','Madison','Claire',NULL,'Jackson','1998-02-19',0,'Austin, USA','+15125550134','madison.jackson@example.com',1,NULL,GETDATE()),
('US100035','Joshua','Daniel','Paul','White','1986-09-27',1,'Portland, USA','+15035550135','joshua.white@example.com',1,NULL,GETDATE()),
('US100036','Abigail','Marie',NULL,'Harris','1994-04-11',0,'Atlanta, USA','+14045550136','abigail.harris@example.com',1,NULL,GETDATE()),
('US100037','Benjamin','Scott',NULL,'Martin','1992-12-08',1,'Seattle, USA','+12065550137','benjamin.martin@example.com',1,NULL,GETDATE()),
('US100038','Natalie','Grace','Anne','Thompson','1997-06-16',0,'Miami, USA','+13055550138','natalie.thompson@example.com',1,NULL,GETDATE()),
('US100039','Samuel','Robert',NULL,'Garcia','1987-01-30',1,'Denver, USA','+13035550139','samuel.garcia@example.com',1,NULL,GETDATE()),
('US100040','Victoria','Jane',NULL,'Martinez','2000-10-03',0,'Orlando, USA','+14075550140','victoria.martinez@example.com',1,NULL,GETDATE()),

('UK100041','Edward','James',NULL,'Roberts','1990-05-17',1,'London, UK','+44205550141','edward.roberts@example.com',2,NULL,GETDATE()),
('UK100042','Jessica','Louise','Marie','Evans','1995-08-09',0,'Manchester, UK','+441615550142','jessica.evans@example.com',2,NULL,GETDATE()),
('UK100043','Thomas','Alexander',NULL,'Lewis','1988-03-21',1,'Birmingham, UK','+441215550143','thomas.lewis@example.com',2,NULL,GETDATE()),
('UK100044','Sophie','Amelia',NULL,'Robinson','1999-12-14',0,'Liverpool, UK','+441515550144','sophie.robinson@example.com',2,NULL,GETDATE()),
('UK100045','Daniel','Henry','George','Walker','1985-07-06',1,'Bristol, UK','+441175550145','daniel.walker@example.com',2,NULL,GETDATE()),
('UK100046','Grace','Charlotte',NULL,'Hall','1998-04-25',0,'Oxford, UK','+441865550146','grace.hall@example.com',2,NULL,GETDATE()),
('UK100047','Matthew','Oliver',NULL,'Allen','1993-09-12',1,'Leeds, UK','+441135550147','matthew.allen@example.com',2,NULL,GETDATE()),
('UK100048','Lucy','Elizabeth','Rose','Young','1996-01-18',0,'Edinburgh, UK','+441315550148','lucy.young@example.com',2,NULL,GETDATE()),
('UK100049','Jack','William',NULL,'King','1991-11-29',1,'Glasgow, UK','+441415550149','jack.king@example.com',2,NULL,GETDATE()),
('UK100050','Amelia','Victoria',NULL,'Wright','2001-06-04',0,'Cardiff, UK','+44295550150','amelia.wright@example.com',2,NULL,GETDATE()),

('CA100051','Liam','Alexander',NULL,'Scott','1992-02-13',1,'Toronto, Canada','+14165550151','liam.scott@example.com',3,NULL,GETDATE()),
('CA100052','Emma','Sophia','Grace','Green','1997-10-20',0,'Vancouver, Canada','+16045550152','emma.green@example.com',3,NULL,GETDATE()),
('CA100053','Jacob','Thomas',NULL,'Adams','1989-06-08',1,'Ottawa, Canada','+16135550153','jacob.adams@example.com',3,NULL,GETDATE()),
('CA100054','Avery','Charlotte',NULL,'Baker','1998-03-16',0,'Calgary, Canada','+14035550154','avery.baker@example.com',3,NULL,GETDATE()),
('CA100055','Logan','Benjamin','James','Nelson','1986-12-24',1,'Montreal, Canada','+15145550155','logan.nelson@example.com',3,NULL,GETDATE()),
('CA100056','Ella','Madison',NULL,'Carter','2000-07-11',0,'Quebec City, Canada','+14185550156','ella.carter@example.com',3,NULL,GETDATE()),
('CA100057','Mason','Daniel',NULL,'Mitchell','1994-05-02',1,'Edmonton, Canada','+17805550157','mason.mitchell@example.com',3,NULL,GETDATE()),
('CA100058','Scarlett','Rose',NULL,'Perez','1995-09-19',0,'Winnipeg, Canada','+12045550158','scarlett.perez@example.com',3,NULL,GETDATE()),
('CA100059','Ethan','Joseph','Ryan','Roberts','1990-01-27',1,'Halifax, Canada','+19025550159','ethan.roberts@example.com',3,NULL,GETDATE()),
('CA100060','Chloe','Isabella',NULL,'Turner','1999-11-06',0,'Victoria, Canada','+12505550160','chloe.turner@example.com',3,NULL,GETDATE()),

('AU100061','Alexander','Jack',NULL,'Phillips','1991-04-15',1,'Sydney, Australia','+61255550161','alexander.phillips@example.com',4,NULL,GETDATE()),
('AU100062','Harper','Emily','Grace','Campbell','1996-08-28',0,'Melbourne, Australia','+61355550162','harper.campbell@example.com',4,NULL,GETDATE()),
('AU100063','Lucas','William',NULL,'Parker','1988-12-02',1,'Brisbane, Australia','+61755550163','lucas.parker@example.com',4,NULL,GETDATE()),
('AU100064','Mila','Sophia',NULL,'Collins','1998-05-23',0,'Perth, Australia','+61855550164','mila.collins@example.com',4,NULL,GETDATE()),
('AU100065','Henry','Edward','James','Stewart','1985-10-09',1,'Adelaide, Australia','+61855550165','henry.stewart@example.com',4,NULL,GETDATE()),
('AU100066','Evie','Charlotte',NULL,'Morris','2001-02-17',0,'Canberra, Australia','+61255550166','evie.morris@example.com',4,NULL,GETDATE()),
('AU100067','Oscar','George',NULL,'Rogers','1993-07-31',1,'Hobart, Australia','+61355550167','oscar.rogers@example.com',4,NULL,GETDATE()),
('AU100068','Ruby','Amelia','Rose','Reed','1997-03-12',0,'Darwin, Australia','+61855550168','ruby.reed@example.com',4,NULL,GETDATE()),
('AU100069','Charlie','Thomas',NULL,'Cook','1990-09-05',1,'Gold Coast, Australia','+61755550169','charlie.cook@example.com',4,NULL,GETDATE()),
('AU100070','Isla','Victoria',NULL,'Morgan','1999-12-21',0,'Newcastle, Australia','+61255550170','isla.morgan@example.com',4,NULL,GETDATE()),

('US100071','Ryan','Patrick',NULL,'Cooper','1994-02-07',1,'Las Vegas, USA','+17025550171','ryan.cooper@example.com',1,NULL,GETDATE()),
('US100072','Zoe','Alexandra',NULL,'Richardson','1998-06-13',0,'San Francisco, USA','+14155550172','zoe.richardson@example.com',1,NULL,GETDATE()),
('US100073','Nathan','Christopher','Lee','Cox','1987-08-26',1,'Philadelphia, USA','+12155550173','nathan.cox@example.com',1,NULL,GETDATE()),
('UK100074','Freddie','Arthur',NULL,'Bailey','1995-01-09',1,'Nottingham, UK','+44115550174','freddie.bailey@example.com',2,NULL,GETDATE()),
('UK100075','Poppy','Eleanor',NULL,'Bennett','2000-04-18',0,'York, UK','+441905550175','poppy.bennett@example.com',2,NULL,GETDATE()),
('CA100076','Oliver','Nathan',NULL,'Wood','1992-11-15',1,'Saskatoon, Canada','+13065550176','oliver.wood@example.com',3,NULL,GETDATE()),
('CA100077','Aria','Madeline',NULL,'Watson','1996-07-03',0,'Regina, Canada','+13065550177','aria.watson@example.com',3,NULL,GETDATE()),
('AU100078','Leo','Samuel',NULL,'Brooks','1989-10-22',1,'Geelong, Australia','+61355550178','leo.brooks@example.com',4,NULL,GETDATE()),
('AU100079','Freya','Elizabeth',NULL,'Kelly','1997-05-14',0,'Townsville, Australia','+61755550179','freya.kelly@example.com',4,NULL,GETDATE()),
('AU100080','Hugo','Maxwell','John','Murphy','1993-12-30',1,'Wollongong, Australia','+61255550180','hugo.murphy@example.com',4,NULL,GETDATE());


INSERT INTO people
(
    NationalNo, FirstName, SecondName, ThirdName,
    LastName, DateOfBirth, Gendor, Address, Phone,
    Email, NationalityCountryID, ImagePath, CreatedDateTime
)
VALUES
('US100081','David','Michael',NULL,'Perry','1991-02-14',1,'New York, USA','+12125550181','david.perry@example.com',1,NULL,GETDATE()),
('US100082','Claire','Elizabeth',NULL,'Powell','1996-05-22',0,'Chicago, USA','+13125550182','claire.powell@example.com',1,NULL,GETDATE()),
('US100083','Anthony','James','Robert','Long','1987-09-17',1,'Boston, USA','+16175550183','anthony.long@example.com',1,NULL,GETDATE()),
('US100084','Audrey','Grace',NULL,'Patterson','1999-01-08',0,'Seattle, USA','+12065550184','audrey.patterson@example.com',1,NULL,GETDATE()),
('US100085','Jonathan','Paul',NULL,'Hughes','1985-11-26',1,'Austin, USA','+15125550185','jonathan.hughes@example.com',1,NULL,GETDATE()),
('US100086','Brooklyn','Marie','Rose','Flores','1998-04-13',0,'Miami, USA','+13055550186','brooklyn.flores@example.com',1,NULL,GETDATE()),
('US100087','Aaron','Matthew',NULL,'Washington','1993-07-19',1,'Denver, USA','+13035550187','aaron.washington@example.com',1,NULL,GETDATE()),
('US100088','Savannah','Jane',NULL,'Butler','1997-12-03',0,'Dallas, USA','+12145550188','savannah.butler@example.com',1,NULL,GETDATE()),
('US100089','Charles','Edward',NULL,'Simmons','1989-03-25',1,'Phoenix, USA','+16025550189','charles.simmons@example.com',1,NULL,GETDATE()),
('US100090','Stella','Victoria',NULL,'Foster','2000-08-11',0,'Portland, USA','+15035550190','stella.foster@example.com',1,NULL,GETDATE()),

('US100091','Dylan','Andrew',NULL,'Gonzalez','1992-06-05',1,'San Diego, USA','+16195550191','dylan.gonzalez@example.com',1,NULL,GETDATE()),
('US100092','Violet','Anne',NULL,'Bryant','1995-10-16',0,'Atlanta, USA','+14045550192','violet.bryant@example.com',1,NULL,GETDATE()),
('US100093','Peter','Joseph','Ryan','Alexander','1986-01-29',1,'Houston, USA','+17135550193','peter.alexander@example.com',1,NULL,GETDATE()),
('US100094','Leah','Madison',NULL,'Russell','1999-07-07',0,'Orlando, USA','+14075550194','leah.russell@example.com',1,NULL,GETDATE()),
('US100095','Jason','Christopher',NULL,'Griffin','1990-12-20',1,'Las Vegas, USA','+17025550195','jason.griffin@example.com',1,NULL,GETDATE()),
('US100096','Penelope','Rose','Grace','Diaz','1997-02-18',0,'San Francisco, USA','+14155550196','penelope.diaz@example.com',1,NULL,GETDATE()),
('US100097','Evan','Nicholas',NULL,'Hayes','1988-05-09',1,'Philadelphia, USA','+12155550197','evan.hayes@example.com',1,NULL,GETDATE()),
('US100098','Lillian','Kate',NULL,'Myers','2001-11-27',0,'Detroit, USA','+13135550198','lillian.myers@example.com',1,NULL,GETDATE()),
('US100099','Connor','Benjamin',NULL,'Ford','1994-04-02',1,'Nashville, USA','+16155550199','connor.ford@example.com',1,NULL,GETDATE()),
('US100100','Hazel','Evelyn',NULL,'Hamilton','1996-09-15',0,'Charlotte, USA','+17045550200','hazel.hamilton@example.com',1,NULL,GETDATE()),

('UK100101','Alfie','James',NULL,'Ward','1992-03-11',1,'London, UK','+44205550201','alfie.ward@example.com',2,NULL,GETDATE()),
('UK100102','Daisy','Florence',NULL,'Cox','1998-06-24',0,'Manchester, UK','+441615550202','daisy.cox@example.com',2,NULL,GETDATE()),
('UK100103','Arthur','Henry','John','Richardson','1987-10-13',1,'Birmingham, UK','+441215550203','arthur.richardson@example.com',2,NULL,GETDATE()),
('UK100104','Millie','Rose',NULL,'Wood','2000-02-05',0,'Liverpool, UK','+441515550204','millie.wood@example.com',2,NULL,GETDATE()),
('UK100105','Oscar','William',NULL,'Watson','1991-08-29',1,'Leeds, UK','+441135550205','oscar.watson@example.com',2,NULL,GETDATE()),
('UK100106','Florence','May','Jane','Brooks','1995-12-17',0,'Bristol, UK','+441175550206','florence.brooks@example.com',2,NULL,GETDATE()),
('UK100107','Theo','Alexander',NULL,'Bennett','1993-04-20',1,'Oxford, UK','+441865550207','theo.bennett@example.com',2,NULL,GETDATE()),
('UK100108','Eleanor','Grace',NULL,'Gray','1997-07-09',0,'Edinburgh, UK','+441315550208','eleanor.gray@example.com',2,NULL,GETDATE()),
('UK100109','Freddie','George',NULL,'James','1989-01-31',1,'Glasgow, UK','+441415550209','freddie.james@example.com',2,NULL,GETDATE()),
('UK100110','Matilda','Alice',NULL,'Barnes','2001-09-14',0,'Cardiff, UK','+44295550210','matilda.barnes@example.com',2,NULL,GETDATE()),

('UK100111','Louis','Edward',NULL,'Fisher','1990-11-22',1,'York, UK','+441905550211','louis.fisher@example.com',2,NULL,GETDATE()),
('UK100112','Georgia','Isabelle',NULL,'Ellis','1996-02-08',0,'Cambridge, UK','+441225550212','georgia.ellis@example.com',2,NULL,GETDATE()),
('UK100113','Stanley','Thomas',NULL,'Harrison','1986-06-19',1,'Nottingham, UK','+44115550213','stanley.harrison@example.com',2,NULL,GETDATE()),
('UK100114','Martha','Louise',NULL,'Gibson','1999-10-03',0,'Brighton, UK','+441275550214','martha.gibson@example.com',2,NULL,GETDATE()),
('UK100115','Albert','Charles',NULL,'Murray','1994-05-27',1,'Sheffield, UK','+441145550215','albert.murray@example.com',2,NULL,GETDATE()),
('UK100116','Esme','Charlotte',NULL,'West','1998-12-12',0,'Newcastle, UK','+441915550216','esme.west@example.com',2,NULL,GETDATE()),
('UK100117','Reuben','Matthew',NULL,'Holmes','1991-07-06',1,'Leicester, UK','+441165550217','reuben.holmes@example.com',2,NULL,GETDATE()),
('UK100118','Imogen','Victoria',NULL,'Palmer','1997-03-16',0,'Bath, UK','+441225550218','imogen.palmer@example.com',2,NULL,GETDATE()),
('UK100119','Sebastian','Oliver',NULL,'Mills','1988-09-21',1,'Coventry, UK','+442475550219','sebastian.mills@example.com',2,NULL,GETDATE()),
('UK100120','Penny','Elizabeth',NULL,'Webb','2000-01-30',0,'Exeter, UK','+441392550220','penny.webb@example.com',2,NULL,GETDATE()),

('CA100121','Gabriel','Thomas',NULL,'Henderson','1992-04-07',1,'Toronto, Canada','+14165550221','gabriel.henderson@example.com',3,NULL,GETDATE()),
('CA100122','Addison','Marie',NULL,'Coleman','1997-08-15',0,'Vancouver, Canada','+16045550222','addison.coleman@example.com',3,NULL,GETDATE()),
('CA100123','Carter','William',NULL,'Jenkins','1989-12-01',1,'Ottawa, Canada','+16135550223','carter.jenkins@example.com',3,NULL,GETDATE()),
('CA100124','Ellie','Sophia',NULL,'Perry','1999-03-26',0,'Calgary, Canada','+14035550224','ellie.perry@example.com',3,NULL,GETDATE()),
('CA100125','Wyatt','Daniel',NULL,'Powell','1985-07-18',1,'Montreal, Canada','+15145550225','wyatt.powell@example.com',3,NULL,GETDATE()),
('CA100126','Nora','Isabelle',NULL,'Long','2000-11-04',0,'Quebec City, Canada','+14185550226','nora.long@example.com',3,NULL,GETDATE()),
('CA100127','Hunter','Joseph',NULL,'Patterson','1993-02-23',1,'Edmonton, Canada','+17805550227','hunter.patterson@example.com',3,NULL,GETDATE()),
('CA100128','Stella','Margaret',NULL,'Hughes','1996-06-10',0,'Winnipeg, Canada','+12045550228','stella.hughes@example.com',3,NULL,GETDATE()),
('CA100129','Isaac','Nathan',NULL,'Flores','1990-10-28',1,'Halifax, Canada','+19025550229','isaac.flores@example.com',3,NULL,GETDATE()),
('CA100130','Aurora','Grace',NULL,'Washington','1998-01-19',0,'Victoria, Canada','+12505550230','aurora.washington@example.com',3,NULL,GETDATE()),

('CA100131','Julian','Robert',NULL,'Butler','1991-05-13',1,'Saskatoon, Canada','+13065550231','julian.butler@example.com',3,NULL,GETDATE()),
('CA100132','Violet','Anne',NULL,'Simmons','1995-09-24',0,'Regina, Canada','+13065550232','violet.simmons@example.com',3,NULL,GETDATE()),
('CA100133','Levi','Christopher',NULL,'Foster','1987-01-06',1,'London, Canada','+15195550233','levi.foster@example.com',3,NULL,GETDATE()),
('CA100134','Lucy','Jane',NULL,'Gonzalez','2001-04-28',0,'Kelowna, Canada','+12505550234','lucy.gonzalez@example.com',3,NULL,GETDATE()),
('CA100135','Aaron','Matthew',NULL,'Bryant','1986-08-16',1,'Barrie, Canada','+17055550235','aaron.bryant@example.com',3,NULL,GETDATE()),
('CA100136','Naomi','Claire',NULL,'Alexander','1999-12-09',0,'Kingston, Canada','+16135550236','naomi.alexander@example.com',3,NULL,GETDATE()),
('CA100137','Eli','Benjamin',NULL,'Russell','1994-03-03',1,'Windsor, Canada','+15195550237','eli.russell@example.com',3,NULL,GETDATE()),
('CA100138','Madeline','Rose',NULL,'Griffin','1997-07-21',0,'Guelph, Canada','+15195550238','madeline.griffin@example.com',3,NULL,GETDATE()),
('CA100139','Caleb','Andrew',NULL,'Diaz','1988-11-12',1,'Moncton, Canada','+15065550239','caleb.diaz@example.com',3,NULL,GETDATE()),
('CA100140','Layla','Victoria',NULL,'Hayes','2000-02-27',0,'Fredericton, Canada','+15065550240','layla.hayes@example.com',3,NULL,GETDATE()),

('AU100141','Archie','James',NULL,'Myers','1992-01-17',1,'Sydney, Australia','+61255550241','archie.myers@example.com',4,NULL,GETDATE()),
('AU100142','Willow','Rose',NULL,'Ford','1998-04-06',0,'Melbourne, Australia','+61355550242','willow.ford@example.com',4,NULL,GETDATE()),
('AU100143','Theodore','Henry',NULL,'Hamilton','1989-07-23',1,'Brisbane, Australia','+61755550243','theodore.hamilton@example.com',4,NULL,GETDATE()),
('AU100144','Piper','Grace',NULL,'Graham','1996-10-18',0,'Perth, Australia','+61855550244','piper.graham@example.com',4,NULL,GETDATE()),
('AU100145','Max','Alexander',NULL,'Sullivan','1985-02-11',1,'Adelaide, Australia','+61855550245','max.sullivan@example.com',4,NULL,GETDATE()),
('AU100146','Evelyn','Charlotte',NULL,'Wallace','1999-05-29',0,'Canberra, Australia','+61255550246','evelyn.wallace@example.com',4,NULL,GETDATE()),
('AU100147','Finn','Oliver',NULL,'Woods','1993-08-14',1,'Hobart, Australia','+61355550247','finn.woods@example.com',4,NULL,GETDATE()),
('AU100148','Sienna','Madison',NULL,'Cole','1997-12-22',0,'Darwin, Australia','+61855550248','sienna.cole@example.com',4,NULL,GETDATE()),
('AU100149','Arthur','Samuel',NULL,'West','1990-06-03',1,'Gold Coast, Australia','+61755550249','arthur.west@example.com',4,NULL,GETDATE()),
('AU100150','Maisie','Eleanor',NULL,'Jordan','2001-09-26',0,'Newcastle, Australia','+61255550250','maisie.jordan@example.com',4,NULL,GETDATE()),

('AU100151','Jasper','William',NULL,'Owens','1991-03-08',1,'Wollongong, Australia','+61255550251','jasper.owens@example.com',4,NULL,GETDATE()),
('AU100152','Indie','Rose',NULL,'Reynolds','1995-07-17',0,'Geelong, Australia','+61355550252','indie.reynolds@example.com',4,NULL,GETDATE()),
('AU100153','Felix','Edward',NULL,'Fisher','1987-10-30',1,'Townsville, Australia','+61755550253','felix.fisher@example.com',4,NULL,GETDATE()),
('AU100154','Matilda','Jane',NULL,'Ellis','1998-02-14',0,'Cairns, Australia','+61755550254','matilda.ellis@example.com',4,NULL,GETDATE()),
('AU100155','Sebastian','George',NULL,'Harrison','1986-05-20',1,'Ballarat, Australia','+61355550255','sebastian.harrison@example.com',4,NULL,GETDATE()),
('AU100156','Evie','Margaret',NULL,'Gibson','2000-08-31',0,'Bendigo, Australia','+61355550256','evie.gibson@example.com',4,NULL,GETDATE()),
('AU100157','Harrison','Jack',NULL,'Murray','1994-11-07',1,'Launceston, Australia','+61355550257','harrison.murray@example.com',4,NULL,GETDATE()),
('AU100158','Ivy','Amelia',NULL,'Barnes','1997-01-25',0,'Mackay, Australia','+61755550258','ivy.barnes@example.com',4,NULL,GETDATE()),
('AU100159','Archie','Thomas',NULL,'Palmer','1988-04-19',1,'Rockhampton, Australia','+61755550259','archie.palmer@example.com',4,NULL,GETDATE()),
('AU100160','Elsie','Victoria',NULL,'Holmes','1999-12-06',0,'Bundaberg, Australia','+61755550260','elsie.holmes@example.com',4,NULL,GETDATE()),

('US100161','Cole','Ryan',NULL,'Morris','1993-05-18',1,'Cleveland, USA','+12165550261','cole.morris@example.com',1,NULL,GETDATE()),
('US100162','Ruby','Madeline',NULL,'Rogers','1998-08-07',0,'Tampa, USA','+18135550262','ruby.rogers@example.com',1,NULL,GETDATE()),
('US100163','Dominic','Paul',NULL,'Reed','1986-11-16',1,'Minneapolis, USA','+16125550263','dominic.reed@example.com',1,NULL,GETDATE()),
('US100164','Alice','Margaret',NULL,'Cook','2000-03-29',0,'Columbus, USA','+16145550264','alice.cook@example.com',1,NULL,GETDATE()),
('US100165','Miles','Joseph',NULL,'Morgan','1991-06-12',1,'Indianapolis, USA','+13175550265','miles.morgan@example.com',1,NULL,GETDATE()),
('US100166','Elena','Sophia',NULL,'Bell','1996-09-23',0,'Raleigh, USA','+19195550266','elena.bell@example.com',1,NULL,GETDATE()),
('US100167','Adrian','Thomas',NULL,'Murphy','1989-01-04',1,'Sacramento, USA','+19165550267','adrian.murphy@example.com',1,NULL,GETDATE()),
('US100168','Molly','Jane',NULL,'Bailey','1997-04-15',0,'Pittsburgh, USA','+14125550268','molly.bailey@example.com',1,NULL,GETDATE()),
('US100169','Xavier','Daniel',NULL,'Rivera','1994-07-28',1,'Kansas City, USA','+18165550269','xavier.rivera@example.com',1,NULL,GETDATE()),
('US100170','Sadie','Grace',NULL,'Cooper','2001-10-10',0,'New Orleans, USA','+15045550270','sadie.cooper@example.com',1,NULL,GETDATE()),

('UK100171','Bobby','Edward',NULL,'Howard','1992-02-16',1,'Southampton, UK','+44235550271','bobby.howard@example.com',2,NULL,GETDATE()),
('UK100172','Megan','Louise',NULL,'Ward','1996-05-08',0,'Portsmouth, UK','+44235550272','megan.ward@example.com',2,NULL,GETDATE()),
('UK100173','Callum','James',NULL,'Price','1988-08-19',1,'Aberdeen, UK','+441225550273','callum.price@example.com',2,NULL,GETDATE()),
('UK100174','Holly','Rose',NULL,'Barker','1999-11-02',0,'Dundee, UK','+441382550274','holly.barker@example.com',2,NULL,GETDATE()),
('UK100175','Elliot','George',NULL,'Wells','1993-01-24',1,'Reading, UK','+441185550275','elliot.wells@example.com',2,NULL,GETDATE()),
('UK100176','Lottie','Grace',NULL,'Armstrong','1997-06-30',0,'Swansea, UK','+441792550276','lottie.armstrong@example.com',2,NULL,GETDATE()),
('UK100177','Blake','Alexander',NULL,'Kennedy','1987-09-13',1,'Derby, UK','+441332550277','blake.kennedy@example.com',2,NULL,GETDATE()),
('UK100178','Maisie','Eleanor',NULL,'Simpson','2000-12-18',0,'Worcester, UK','+441905550278','maisie.simpson@example.com',2,NULL,GETDATE()),
('UK100179','Rory','William',NULL,'Dixon','1990-04-09',1,'Inverness, UK','+441463550279','rory.dixon@example.com',2,NULL,GETDATE()),
('UK100180','Freya','Alice',NULL,'Harvey','1998-07-27',0,'Canterbury, UK','+441227550280','freya.harvey@example.com',2,NULL,GETDATE());




select people.PersonID  ,  people.ImagePath from people



select * from users


select * from roles

ALTER TABLE Users
ADD PasswordSalt NVARCHAR(100) NOT NULL DEFAULT '';

select * from people



                SELECT UserID, PersonID, UserName, Password, users.PasswordSalt ,IsActive,
                       RoleID, SignUpDateTime, IsLocked
                FROM dbo.Users
                WHERE UserName = 'User8'
                  AND MarkForDelete = 0


ALTER TABLE PasswordsHistory
ADD PasswordSalt NVARCHAR(100) NOT NULL DEFAULT '';



exec sp_helptext 'SP_AddNewPasswordHistory'



  
alter PROCEDURE SP_AddNewPasswordHistory  
    @UserID INT,  
    @PasswordChange DATETIME,  
    @Password NVARCHAR(255),  
    @PasswordSalt NVARCHAR(100) ,
    @NewPasswordHistoryID INT OUTPUT  
    
AS  
BEGIN  
    INSERT INTO PasswordsHistory  
    (  
        UserID,  
        PasswordChange,  
        Password  ,
        PasswordSalt
    )  
    VALUES  
    (  
        @UserID,  
        @PasswordChange,  
        @Password  ,
        @PasswordSalt
    );  
  
    SET @NewPasswordHistoryID = SCOPE_IDENTITY();  
END;





UPDATE U
SET U.[Password] = V.[Password],
    U.PasswordSalt = V.PasswordSalt
FROM dbo.Users AS U
INNER JOIN
(
    VALUES
        ('User1', 'gcmfxCNh1Lv5Ixe34sVR+TzeTKybyz7otdVKZOMeZP4=', 'eAuo+m/u1RIPtKEifk6G2Q=='),
        ('User2', 'bgw37SDmiRiY35zydo44z1dlB59Hn6CIma+IcnoTcG8=', 'oQ9FnVTv0AxLBZZbigKJNQ=='),
        ('User3', 'Bnuq8be3rfaYIxALx5C5HKZjH829mZs7rf6j8Y4accc=', 'l98tj8nY6jEsQUSCEqUg7Q=='),
        ('User4', 'dOPWOkVLVVF1/U7wIOZYlWF7sDHyHo+sAhKVr17tiyk=', 'Ch1FA5hsqUPF//hDPejXDg=='),
        ('User5', 'JZ0ByPpBbSUWcmkwQ3zRrdmY0mIt/zdukefpRELxzsE=', 'il+uZnYBKi4Dgrb75YvYhg=='),
        ('User6', 'BWDqmOYTDdc9BCcp97ZRSjlo5MGwk7DzV1oZHB1i+0U=', 'QQOJCB2YgODw0cPZQgdWig=='),
        ('User7', 'i7iVCZ6S9+BY0i+Yw4UMGJF3AmnZASsDJT/tP1nEp0c=', 'Bs3XsfJXI0pQAeW52h2FvA=='),
        ('User8', 'uFsAwhKEckVGRjzdvpa7JaMsDNwS2/YuL//pWm7RwUE=', '8danWe34gZI2WYmOVnhAIw=='),
        ('User9', '8KJBDl8ySvCfWXiKqbHdkttWHsbnESUVPJVkDcSxJZE=', 'Yv4P8cgH4o3qiV+9RgD5mQ=='),
        ('User10', 'O3CKqRNPIbfrBr6oCCsUjOguLJwnTRpglPax3AgTBXA=', 'FlQsexw2e4/wPbi+36w7Cg=='),
        ('User11', '8NzdLzr2bjj3s5p/0tkB7q6p5/FTnwhMPdlhQ/MNois=', 'Ltrz6cg5tt4Wg2Y93FpKjQ=='),
        ('User12', 'Cd79y0iY6rNFwZhUUnd57cfFxfpT0VhJlCCwvzU5ka8=', 'UFcm6G7t7TOpfyDtOd/22A=='),
        ('User13', 'sDfOmt4/oZxq0aMYcGhOs1StkpmY0kb2fVa7hdFHlsQ=', 'wVr5q0yiijfsfmi0SU2Meg=='),
        ('User14', 'YONsD2N5Otke/ZpaguzO+cl84cPcAqHo+Oq8S2FzBK4=', '8kefyzm1d/zQRgAzuxrWDg=='),
        ('User15', '11VI0z+5knB5Sc4iJqHwv1EfXbWBw83fg1NU0uDvEH4=', 'SWHWrpqs5uA/WSkMjxdQ1g=='),
        ('User16', '1hxYXOb8iXZjDQ4s9L9jN4G2G5PtUipIoAxt9LoEn3A=', 'zngK4w/kPKOuyBMrBAEnJA=='),
        ('User17', 'nmPIH1LM6ewlL87Cw5UnJf2HbRRgUwy9XbpYghyIpJs=', 'eQm5URwYidiwMFkjFQUpdA=='),
        ('User18', 'cVdBE1tD3M5tjDVwItn0Rj3E8gv6Rcc515ACDkbEsUs=', 'dHz9nPmewqsOMo55uxPLHA=='),
        ('User19', 'leNlE2cOyAVN6hziACJnK16cM19EX8sAO9Ir8tD60tE=', 'SDJbBuAYrfv/H5V7o0Sm6g=='),
        ('User20', 'w2aPSQDfxZ8IFX3K7HsXMMFeXuBucejiKINqdFpW6b8=', 'RH8F8XM8R/lJb7rdSD/sGg=='),
        ('User21', 'jVKSdwRIRDpx9mzfz709pSDcl4XYgAVu1Fc0ddCDj0s=', 'CsFNsDLIQioNRkEoUDG54g=='),
        ('User22', 'ryc8P++z07YqFm3XIzImyI1SR2ZqYyy+EV0UARDp/Vo=', 'ILx84oeJjKBRqIMvm8WILA=='),
        ('User23', 'E6f5c6IveM+NIHrNVKmm1nA4pXcmsuFQ6kdNf3S5/R8=', 'lsqs2mP7+Bv2ZYdOFmttmw=='),
        ('User24', 'zZl+0c7D7rN6QrvVYXu9So/E0QPUIYyzQtKBHU9/c0U=', 'MiGBJTxgrJ4Nn8Kv6BgUdg=='),
        ('User25', 'TC2XnIIG2GLb+D86kfTHgBoamBplOCqMR0BsnmFE6Pc=', 'TeE30+iZFUQuHkvCewux1w=='),
        ('User26', 'vtDXWqkLrZwWT8Ew76TAvQC/fYsYfW3B4xnlQP/Q5pA=', 'Ijgaqp9HFKag4bexAe9jWg=='),
        ('User27', '1KCcjJqo5e8CRlAdX+lGcyqC6Hc0yuDgDrRcAaArYGk=', '3/WrxBz5uwfSKRuyT/Ly7w=='),
        ('User28', 'IEGtyuFJu9LmvtPtCKviPGZU8jr99IVJFFeVPM9v40o=', 'fx4pjD3BihvezDrZ7sQsgQ=='),
        ('User29', 'KAsgJM6kC6qsSDxpeQdRZMpKzZouZBGK9b3u2ymiKO8=', 'SpbL9stiOGBw5lgwOm50SA=='),
        ('User30', 'cyWh//j1MEK1Gg8UYd824PbzkykFOxptSPJwRmMcHA8=', 'OGZqBylHqLww25MIOfbCDw=='),
        ('User31', 'k/fTSVMfjotDffGL3xv+Znj+8urJ/OxjjHcIyc5Dhh4=', 'hxDaXG7PTT/F3Yal/FWJdw=='),
        ('User32', 'nHIhfG0vvM/7gSZIL20S66k9ww8bkRFFYqo425iWPnM=', 'Zjnnd4KOhkNZCNDAp4FjZw=='),
        ('User33', 'uAnmmmzJC/SsSSHkQzalsrEOIQH7PIN460CQLHx9QTY=', 'JvJ1HgmGlFZbYKMJiJ2NDA=='),
        ('User34', 'k2LspTbBDxI43Ow+vSDbLH9z0s4vHY8fS1jEhTerl9I=', '8QXlmN2mZM7pKtj6bK0XGA=='),
        ('User35', 'PwvofvEvepBnQ0Fzyiek5LWzpuG2hcxunHxFSKy6f+M=', '/DHJRbFRjwoK3ba6XWja7g=='),
        ('User36', '553LQvcdJjh2qYxW3/yHCU32zQKH+D1Vi/u0E+4eUV8=', '5aWoVP06zqYsKASEs2mD6A=='),
        ('User37', 'mWU/QBsd24V4tO4z41BKXAVPeUHKUSXw6EpVDu4kGU8=', 'KfWFn9qh8ftWl6HR0WRaDA=='),
        ('User38', 'QVsfRfd9m04jgkxSLMS1aLpMoF7xAvvmVBkHIyk/ekU=', 'tDqCqGl7dOcatNi4d+B7sw=='),
        ('User39', 'XplVPsgLhoUz24n/a6hoSxQBbLn1+xcM69P/JWFhkD4=', 'f+P+qyoFf/hbqQs4p6uInA=='),
        ('User40', 'j8/5tgpHB/p4Trhmh8biTNnu86OcJfwoXKyo2O7CYkg=', 'D/vo4kNYu5aLDrQAp6IkZw=='),
        ('User41', 'iiqp7pIt2rP8kkvpBYxLyDiHwXABd5x5rk8J6EuiP7k=', 'W3nzqwTTWCuViafhgNub/A=='),
        ('User42', 'IOAvfSXYTmQtsgfACDq6/vQALULECtW1RUOetq59drs=', 'K3fo7KW7OFBgJwTbh51P3Q=='),
        ('User43', 'eB0AXYb8Vb2oNUez20fhHu7604PI+nDjo7A63eTTwYU=', 'ri+ps1SjgKCkByAe4+1Vmg=='),
        ('User44', '8tTme62QarfRZxoig7AGLPzdoJYo0uoD7AH4c7s7xzI=', 'jO6HMUwuBGSM2DrRFQDUNg=='),
        ('User45', 'xL/14j6wHC/+txe5WApkMrGnUbV1jFBfco82T2gEECY=', 'Q4ugQK3t9uNQw/XHbbcDNQ=='),
        ('User46', 'CAfnIqK0XecKqg7pYSr1yuvPLiSfVoDBcvvAGzjoy9E=', 'vwr/+3EMObPjCH962t6fxQ=='),
        ('User47', 'zU2ROSB015Jj8XADYepVY7EmM/lGYizjUp2F1Hv+RBI=', 'f6ZHlJ7rl6rIE9L+BXAa4Q=='),
        ('User48', 'fVzz0Fg3BtNuS2/8PfW3yJEvDhLc+Gb16rQeRlNzn3o=', 'uwyLVItR9HiqVxmnrPLFWw=='),
        ('User49', 'ckpJA7St6EhtYjglxnMmvfKrzUuUALzb2JOstko4ySM=', 'bPJLX3NFZpKirpNLyDAaPw=='),
        ('User50', 'ahZe1fR15nsgAxiz0siw0ks1lyOAK29UogWeTOawPR8=', 'YzOIH0Ck6wGBv/B0xUeLng=='),
        ('User51', 'fcJvW1iZT8S8zPUz4E/nPtvZ2CrNQQsOR8Bp0szlywA=', 'mwKVUhpKiQqgh6N6NvG5iQ=='),
        ('User52', 'f2mrdl8TTCT2iJzURcvp4bYws5eV1rwB/k0MMJJq6pI=', 'fdXtiGMObfs2b2QZZ3Nh2Q=='),
        ('User53', 'r8Ahre3gkiUJpNFUnpvM6BYJbIdg7OEYb4x5kDyvqUs=', 'wCvrAoAy/Pa1kUdPryrwJQ=='),
        ('User54', '6n8KFAHWjEMUiTeklCWNQMB3x5UaCY3l0tIALU/yV2o=', 'QIJdyaewNkzws1V8TzEwHA=='),
        ('User55', 'gmRF6JxUy6uQ7jU4vBcEl5eEdi+x922fXUmrwSOZGwc=', 'wCWE3fq4zMer6dmXXe5/PA=='),
        ('User56', 'gPhKs+LWqxKNRJqUpRrZdSnuVW0iPgV/3w/pHYSmPgQ=', 'Q0KPRUXxv3c5uQb0qdBjFg=='),
        ('User57', 'XOex6lXS7/gx7cpD0B0o4CeqvhWxUg8O0aP2bkYea/Q=', 'lNSKDgS76R/x8390UVPm/A=='),
        ('User58', 'bARiV5ZRifYQW/0S74rZ6E8oE2n/1M6fEDMhFCu/Ql8=', 'T7Qrmq6LD2azIaB6wQlu5Q=='),
        ('User59', 'pUPPYs/KaJB2VzYsGCeBudUAs6jEcQZzCs9Aak3W0eo=', 'jAJhzICmESPPd6ikXMIU5A=='),
        ('User60', 'PsZVVeGVWdDJuABcoFOn4NhY8xnwfjGrnQ09/QIx+nA=', '1vfxn1mbw8ft5ijMK2WaEQ=='),
        ('User61', '7emkd9ajYdneT60qFi2K6/G6XqQv5KBhfl6iW4EoPAU=', 'fNyn8nnNIA/7SSGyX0fPIA=='),
        ('User62', 'uiJP8NFqgXiMmg7W/8Oy6ra8pQH792B94z5Norlkp+8=', 'RokXVn4sKp8W3L3QQiBP9A=='),
        ('User63', 'OgYkKVBXXK4Pp22ytgh+TluYX6JZCYxi8/mEQbCtR7s=', 'xvV4UL1E0gCniq220CGvUA=='),
        ('User64', '44AWnD4o1fSivBM643+7QczOpWhQDd3YgHaU3ez65v8=', 't+hhAuOhI9pUrvSDgraKzA=='),
        ('User65', 'yi69p1SxqrPjWTa8i8CAEtguSRSIHs5XszBq0s1Mbfk=', 'e9zn/h+OgknM9FsWbMiuPg=='),
        ('User66', 'XmMvPGsJR2YAyl2IEOqdtlJiMtDOThkjNh8hiGONo/Q=', 'ZA5BwTrEoKuZwEr4mwd4hQ=='),
        ('User67', 'rFk4zGOUmwIQoTi1MRUqES+H1GpvEwl7sBGZBFelyME=', 'Q3NgdSFcpPQge6HFGdBk2w=='),
        ('User68', 'dH50FeUctrvE8EYa6PF/Q8JX+q+AodiBEDXNcWIWrno=', '3Oyq0YQ7la2c5xmkA4LUuA=='),
        ('User69', 'OGfecP/uTZfNQ0lGiNOIlCK64VCOCLjXkFSTN1WjkmQ=', 'TSDI4/hmgya6KN0g3K7rgw=='),
        ('User70', '/gX4ctnBBbln0blkr64hpaIrs6KpD5nbi4ygpjB3Vsw=', 'rmvS1gw8w7JnkJ9AKk0LFA=='),
        ('User71', 'SSCBW/Bquwv/yMdTWQvElrk0KR05xfSO3vuxpIVJ95Y=', '1Ao6sz/qlpdWPH8ojQdCFw=='),
        ('User72', 'dbybiKWv9l04TftLkooJ2paELbXJH5NvAsxd7bA3SKw=', 'N2p6Nxhm2zF2MfN8gh4jcw=='),
        ('User73', 'trCmA9pbch9ZwOLQLH7hh5qW3y8RZDTXMX40FoAalrk=', 'r6epBR5J3RWXtFQQjr07Hw=='),
        ('User74', 'Ds6I40+11J0TFkaLOp9qV5Il8YASEAKwr6S4teVy5Lo=', '8EVmrnH0UQKRydDjLkmtMg=='),
        ('User75', '5hvJ0zQGB2Ma4/OWNjah4+2sc+yrSsjqyGH3VonSw6s=', '18+/++xngLS6GZ6tgW1IqA=='),
        ('User76', 'VT5Xwxe5Z1H6IS/arG7g7CvmeqDDIyUVwegVusm5FKU=', '0+qdlfXr1jREpZDlsEG71g=='),
        ('User77', 'hYtpjIgKuG6RWKNrf+0by+A1ftzqOWA4LVzaPHMRQuw=', 'pHwwWsBAd3bfEEm+d3cDOQ=='),
        ('User78', '8SVtgYE8Oi9nxE2v52i9xEJxESlkypkOuerdvxvrhNM=', 'rin5m/UrvwZUuyPklvqkAw=='),
        ('User79', 'jjLMY//wo9K0aSv9IbWzoWJ19Nb3RPMck/1VBYq+68c=', '8JLzetT0cent04ot1XtxWg=='),
        ('User80', 'mN00v0uxU0DD9i4Gc7rQAZkg3DobcFqog8DE//MQUaM=', 'slpTU7PL7KkKHAP9Z/60dg=='),
        ('User81', '56oJiHKv4AyFnWocJm4eMto3X9ijl1SGKeVdnT1jZCM=', '9sdDrT9weWvtnqna5D1a6w=='),
        ('User82', 'Vy7Cx1/N74nRtu1VF65v1m3V8S2+48HqE4eJGwVSKCI=', 'dUJ7yew7FxCi6aVoBPbEzg==')
) AS V(UserName, [Password], PasswordSalt)
    ON U.UserName = V.UserName;




    exec sp_helptext 'SP_CheckActiveScheduledTest'

 alter PROCEDURE SP_CheckActiveScheduledTest  
    @LocalDrivingLicenseApplicationID INT,  
    @TestTypeID INT  
AS  
BEGIN  
    IF EXISTS (  
        SELECT 1  
        FROM LocalDrivingLicenseApplications  
        INNER JOIN TestAppointments  
            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =   TestAppointments.LocalDrivingLicenseApplicationID  
        WHERE TestAppointments.LocalDrivingLicenseApplicationID =   @LocalDrivingLicenseApplicationID
          AND TestAppointments.TestTypeID = @TestTypeID
          AND TestAppointments.IsLocked = 0  
    )  
        SELECT 1;  
    ELSE  
        SELECT 0;  
END;  




select * from LocalDrivingLicenseApplications

select * from testAppointments


        SELECT COUNT(*)
        FROM Tests
        INNER JOIN TestAppointments ON Tests.TestAppointmentID =  TestAppointments.TestAppointmentID


        WHERE LocalDrivingLicenseApplicationID =  50
          AND TestResult = 1


          select * from LocalDrivingLicenseApplications_View

          select * from TestAppointments
          select * from tests




             SELECT COUNT(*)
   FROM dbo.DetainedLicenses
   WHERE IsReleased = 0
     AND DetainDate >= DATEADD(DAY, -30, GETDATE())
     AND DetainDate <= GETDATE();


                       SELECT *
                  FROM dbo.Licenses
                  WHERE LicenseID = 40



 select * from LocalDrivingLicenseApplications_View

 select * from testappointments

 select * from tests

 delete tests where testID=508


 select * from  licenses where 




SELECT        Licenses.LicenseID, LicenseClasses.ClassName, Licenses.LicenseClassID AS Expr1
FROM            Licenses INNER JOIN
                         LicenseClasses ON Licenses.LicenseClassID = LicenseClasses.LicenseClassID

where Licenses.LicenseClassID = 3 and isactive = 1 



exec sp_helptext 'SP_AddNewPerson'


CREATE PROCEDURE SP_AddNewPerson  
    @NationalNo NVARCHAR(50),  
    @FirstName NVARCHAR(100),  
    @SecondName NVARCHAR(100),  
    @ThirdName NVARCHAR(100),  
    @LastName NVARCHAR(100),  
    @DateOfBirth DATETIME,  
    @Gendor BIT,  
    @Address NVARCHAR(500),  
    @Phone NVARCHAR(20),  
    @Email NVARCHAR(100),  
    @NationalityCountryID INT,  
    @ImagePath NVARCHAR(250),  
    @CreatedDateTime DATETIME,  
    @NewPersonID INT OUTPUT  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    INSERT INTO People  
    (  
        NationalNo,  
        FirstName,  
        SecondName,  
        ThirdName,  
        LastName,  
        DateOfBirth,  
        Gendor,  
        Address,  
        Phone,  
        Email,  
        NationalityCountryID,  
        ImagePath,  
        CreatedDateTime  
    )  
    VALUES  
    (  
        @NationalNo,  
        @FirstName,  
        @SecondName,  
        @ThirdName,  
        @LastName,  
        @DateOfBirth,  
        @Gendor,  
        @Address,  
        @Phone,  
        @Email,  
        @NationalityCountryID,  
        @ImagePath,  
        @CreatedDateTime  
    );  
  
    SET @NewPersonID = SCOPE_IDENTITY();  
END;




select * from users


alter VIEW dbo.DetainedLicenses_View  
AS  
SELECT        dbo.DetainedLicenses.DetainID, dbo.DetainedLicenses.LicenseID, dbo.DetainedLicenses.DetainDate, dbo.DetainedLicenses.IsReleased, dbo.DetainedLicenses.FineFees, dbo.DetainedLicenses.ReleaseDate,   
                         dbo.People.NationalNo, dbo.People.FirstName + ' ' +ISNULL(dbo.People.ThirdName, '') + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName, dbo.DetainedLicenses.ReleaseApplicationID  
FROM            dbo.People INNER JOIN  
                         dbo.Drivers ON dbo.People.PersonID = dbo.Drivers.PersonID INNER JOIN  
                         dbo.Licenses ON dbo.Drivers.DriverID = dbo.Licenses.DriverID INNER JOIN     
                         dbo.DetainedLicenses ON dbo.Licenses.LicenseID = dbo.DetainedLicenses.LicenseID  


                   select * from dbo.DetainedLicenses_View  




      SELECT COUNT(*)
  FROM dbo.InternationalLicenses
  WHERE IssueDate BETWEEN
        DATEADD(DAY, -30, GETDATE())
        AND
        DATEADD(DAY, 0, GETDATE())





UPDATE Licenses
SET IssueDate = DATEADD( DAY,  ABS(CHECKSUM(NEWID())) % DATEDIFF(DAY, '20210101', '20270101'),'20210101')
where licenseID>105;


       SELECT
            InternationalLicenseID,
            ApplicationID,
            DriverID,
            IssuedUsingLocalLicenseID,
            IssueDate = cast( IssueDate as date) ,
            ExpirationDate = cast(ExpirationDate as date) ,
            IsActive
        FROM InternationalLicenses
        ORDER BY IsActive, ExpirationDate DESC








alter PROCEDURE SP_AddNewPerson  
    @NationalNo NVARCHAR(50),  
    @FirstName NVARCHAR(100),  
    @SecondName NVARCHAR(100),  
    @ThirdName NVARCHAR(100),  
    @LastName NVARCHAR(100),  
    @DateOfBirth DATETIME,  
    @Gendor BIT,  
    @Address NVARCHAR(500),  
    @Phone NVARCHAR(20),  
    @Email NVARCHAR(100),  
    @NationalityCountryID INT,  
    @ImagePath NVARCHAR(250),  
    @CreatedDateTime DATETIME,  
    @NewPersonID INT OUTPUT  
AS  
BEGIN  
     
  
    INSERT INTO People  
    (  
        NationalNo,  
        FirstName,  
        SecondName,  
        ThirdName,  
        LastName,  
        DateOfBirth,  
        Gendor,  
        Address,  
        Phone,  
        Email,  
        NationalityCountryID,  
        ImagePath,  
        CreatedDateTime  
    )  
    VALUES  
    (  
        @NationalNo,  
        @FirstName,  
        @SecondName,  
        @ThirdName,  
        @LastName,  
        @DateOfBirth,  
        @Gendor,  
        @Address,  
        @Phone,  
        @Email,  
        @NationalityCountryID,  
        @ImagePath,  
        @CreatedDateTime  
    );  
  
    SET @NewPersonID = SCOPE_IDENTITY();  
END;

DECLARE @NewPersonID INT;
DECLARE @DOB DATE = DATEFROMPARTS(2002, 2, 19);
DECLARE @CreatedDate DATETIME = GETDATE();

EXEC SP_AddNewPerson
    @NewPersonID = @NewPersonID OUTPUT,
    @NationalNo = 'US504789',
    @FirstName = 'alex',
    @SecondName = NULL,
    @ThirdName = NULL,
    @LastName = 'Arthor',
    @DateOfBirth = @DOB,
    @Gendor = 0,
    @Address = 'San Fransisco 105 street avenue',
    @Phone = '0545457845',
    @Email = 'alexarthor@gmail.com',
    @NationalityCountryID = 90,
    @ImagePath = NULL,
    @CreatedDateTime = @CreatedDate;

SELECT @NewPersonID AS NewPersonID;


