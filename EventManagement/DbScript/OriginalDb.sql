--create database Event_Management
use Event_Management

	create table AppUser(Id int identity primary key,
	FirstName varchar(500)not null,
	LastName varchar(500) not null,
	Email varchar(500)not null,
	Password varchar (1000) not null,
	PhoneNumber varchar(500) not null
)

 Create table Sections(ID int identity primary key,
   Name varchar(500),
)

   Create table Permission(ID int identity primary key, 
   UserID int foreign key references AppUser(ID) not null,
    SectionID int foreign key references Sections(ID) not null,
 )

   Create table UserEvent_Permission(ID int identity primary key,
   UserID int foreign key references AppUser(ID) not null,
   PermissionID int foreign key references Permission(id) not null
 )

   Create table ActivityTPYES(ID int identity primary key,
   Name varchar (500),
  ) 

  Create table Event(ID int identity primary key
  )

  Create table Activites(ID int identity primary key,
  EventID int foreign key references Event(ID),
  Description varchar(500) not null,
  Thumbnail varchar(500) not null,
  StartTime datetime not null ,
  EndTime datetime not null ,
  Address varchar(500)not null,
  CreateON datetime,
  Status bit ,
  ActivityTypeid int foreign key references ActivityTPYES(id) not null,
  )
  
  Create table QRCode(ID int identity primary key,
  EventID int foreign key references Event(ID) not null ,
  Description varchar(500) not null ,
  AtivitityID int foreign key references Activites(ID) not null,
  WebURL varchar(1000) not null ,
  GeneratedON datetime,
  GeneratedBY int default'0',
  Status bit
  )

  Create table FloorMapping(ID int identity primary key,  
  EventID int foreign key references Event(ID)not null,
  PhotoURL varchar(500),
    )

  Create table FloorRegionMapping(ID int identity primary key,
  EventID int foreign key references Event(ID)not null,
  FMid int foreign key references FloorMapping(id) not null,
  Description varchar(500),
  X int,
  Y int,
  Width Decimal(16,2),
  height Decimal(16,2),
  
  )


  Create table Photos(ID int identity primary key,
  EventID int foreign key references Event(ID),
  URL varchar(1000),
  UploadON datetime,
  UploadBY int,
  Description varchar(500),
  Status bit,
  )


  Create table Attendes(ID int identity primary key,
  Name varchar(500),
  Description varchar(500),
  Thumbnail varchar(500),
  FacebookURL varchar(1000),
  TwitterURL varchar(1000),
  InstagramURL varchar(1000),
  AddedON datetime,
  AddedBY int,
  Status bit,
  DeviceToken varchar(500),
  )

  Create table PostType(ID int identity primary key,
  Name varchar(50) not null,  
  )
  
 
  Create table SocialForum(ID int identity primary key,
  EventID int foreign key references Event(ID)not null,
  URL varchar(1000),
  UploadON datetime,
  UploadBY int,
  Description varchar(500),
  PostTypeid int foreign key references PostType(id) not null,
  ApprovedON datetime,
  ApprovedBY int default'0',
  Status bit,
  TotalLikes int,
  AttendesID int foreign key references Attendes(ID) not null
  )

  Create table Sponsors(ID int primary key,
  Description varchar(500),
  Thumbnail varchar(500),
  DocURL varchar(1000),
  Status bit,
  Name varchar(500) not null,
  )


  Create table Notifications(ID int identity primary key,
  EventID int foreign key references Event(ID)not null,
  Text varchar(500),
  AddedON datetime,
  AddedBY int default 0,
  Status bit,
  AttendesID int foreign key references Attendes(ID) not null,
  )


  Create table Theme(ID int identity primary key,
  EventID int foreign key references Event(ID) not null,
  SplashScreemURL varchar(1000),
  AppBackgroundURL varchar(1000),
  ButtonURL varchar(1000),
  ButtonBackgroundColor varchar(10),
  ButtonForegroundColor varchar(10),
  LabelForegroundColor varchar(10),
  HeadingForegroundColor varchar(10),
  )

  Create table AttendesEvents(ID int identity primary key,
  AttendesID int foreign key references Attendes(ID) not null,
  EventID int foreign key references Event(ID) not null,
  )

  Create table SponsorsEvents(ID int identity primary key,
  SponsorID int foreign key references Sponsors(ID) not null,
  EventID int foreign key references Event(ID) not null,
  )

  Create table BookMark(ID int identity primary key,
  ActivityID int foreign key references Activites(ID) not null,
  AttendesID int foreign key references Attendes(ID) not null,
  )

  Create table PostUserLike(ID int identity primary key,
  PostID int foreign key references SocialForum(ID) not null,
  AttendesID int foreign key references Attendes(ID)not null,
  )

  Create table ForumSocialComments(ID int identity primary key,
  PostID int foreign key references SocialForum(ID) not null,
  AttendesID int foreign key references Attendes(ID) not null ,
  Comments varchar(500),
  ApprovedON datetime,
  ApprovedBY int default'0',
  CommentedON datetime,
  ReplyerID int foreign key references AppUser(ID) not null,
 )

  Create table QRHistory(ID int identity primary key,
  QRid int foreign key references QRCode(id) not null,
  AttendesID int foreign key references Attendes(id) not null,
  CommentON datetime,
  )
  
--User Session Table user login sessions will be stored in this table
	create table UserSession(Id int identity primary key,
	AuthToken varchar(200),
	Platform varchar(200),
	UserID int foreign key references AppUser(ID),
	AttendesID int foreign key references Attendes(ID) ,
	CreateDate datetime,
	IsActive bit)
  