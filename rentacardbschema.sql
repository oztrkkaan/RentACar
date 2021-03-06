USE [RentACarDb]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[BookingTime] [smallint] NOT NULL,
	[BookingEndDate] [datetime] NOT NULL,
	[Amount] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](20) NOT NULL,
	[Model] [nvarchar](30) NOT NULL,
	[ModelYear] [smallint] NOT NULL,
	[CarPlate] [nvarchar](8) NOT NULL,
	[VIN] [nvarchar](17) NOT NULL,
	[Color] [nvarchar](15) NOT NULL,
	[DailyRentCost] [decimal](7, 2) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Currency] [tinyint] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAddresses]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAddresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](20) NOT NULL,
	[DistrictName] [nvarchar](20) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[FullAddress] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CustomerAddresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerPhones]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPhones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LandPhone] [nvarchar](11) NULL,
	[OfficePhone] [nvarchar](11) NULL,
	[MobilePhone] [nvarchar](11) NULL,
	[CustomerId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[CompanyTitle] [nvarchar](100) NULL,
	[Gender] [tinyint] NOT NULL,
	[BirthDate] [date] NOT NULL,
	[CitizenshipNumber] [bigint] NOT NULL,
	[TaxNumber] [bigint] NULL,
	[TaxAdministration] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PasswordHash] [varbinary](250) NOT NULL,
	[PasswordSalt] [varbinary](250) NOT NULL,
	[Roles] [nvarchar](75) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Cars]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Customers]
GO
ALTER TABLE [dbo].[CustomerAddresses]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddresses_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[CustomerAddresses] CHECK CONSTRAINT [FK_CustomerAddresses_Customers]
GO
ALTER TABLE [dbo].[CustomerPhones]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPhones_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[CustomerPhones] CHECK CONSTRAINT [FK_CustomerPhones_Customers]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllBookingsByCarId]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetAllBookingsByCarId] @CarId int
as
begin
Select * from Bookings inner join Customers on Bookings.CustomerId = Customers.Id where Bookings.CarId = @CarId;
end
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCars]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllCars]
as
Select * from cars
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCustomers]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllCustomers]
as
Select * from Customers
GO
/****** Object:  StoredProcedure [dbo].[spGetCarById]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetCarById] 
@Id int
as
Select * from Cars where Id =@Id
GO
/****** Object:  StoredProcedure [dbo].[spGetUserByEmail]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUserByEmail] 
@Email nvarchar(50)
as
select * from Users where Email = @Email
GO
/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetUserById] @Id int
as
Select Id, FullName,Email,Roles from Users where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[spInsertBooking]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertBooking]
@CustomerId int,
@CarId int,
@BookingDate date,
@BookingEndDate date
as
begin
insert into Bookings(Amount,BookingDate,BookingEndDate,BookingTime,CarId,CustomerId)
values
(
(select DailyRentCost from Cars where Id =@CarId) * datediff(day,@BookingDate,@BookingEndDate),
@BookingDate,
@BookingEndDate,
datediff(day,@BookingDate,@BookingEndDate),
@CarId,
@CustomerId
)
Select * from Bookings left join Customers on Bookings.CustomerId = Customers.Id where Bookings.Id = SCOPE_IDENTITY();

end
GO
/****** Object:  StoredProcedure [dbo].[spInsertCar]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertCar]
@Brand nvarchar(20),
@Model nvarchar(30),
@ModelYear smallint,
@CarPlate nvarchar(10),
@VIN nvarchar(17),
@Color nvarchar(15),
@DailyRentCost decimal(7,2),
@Type tinyint,
@Currency tinyint
as
Begin
Insert Into dbo.Cars
(
Brand,
Model,
ModelYear,
CarPlate,
VIN,
Color,
DailyRentCost,
[Type],
Currency
)
Values
(
@Brand,
@Model,
@ModelYear,
@CarPlate,
@VIN,
@Color,
@DailyRentCost,
@Type,
@Currency
)

Select * from Cars where Id = (Select SCOPE_IDENTITY())
End
GO
/****** Object:  StoredProcedure [dbo].[spInsertCustomer]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertCustomer] 
@FullName nvarchar(50),
@Gender tinyint,
@BirthDate date,
@CitizenshipNumber bigint,
@LandPhone nvarchar(11),
@OfficePhone nvarchar(11),
@MobilePhone nvarchar(11),
@CityName nvarchar(20),
@DistrictName nvarchar(20),
@FullAddress nvarchar(100)=null
as
begin
begin transaction;
save transaction savePoint
begin try
insert into Customers(
FullName,
BirthDate,
CitizenshipNumber,
Gender
) values(
@FullName,
@BirthDate,
@CitizenshipNumber,
@Gender
)
declare @CustomerId int 
Set @CustomerId = SCOPE_IDENTITY()

insert into CustomerPhones(CustomerId,LandPhone,MobilePhone,OfficePhone) values (@CustomerId,@LandPhone,@MobilePhone,@OfficePhone)
insert into CustomerAddresses(CityName,CustomerId,DistrictName, FullAddress) values (@CityName,@CustomerId,@DistrictName,@FullAddress)
commit transaction
select * from Customers where Id = @CustomerId

end try
begin catch
if @@TRANCOUNT >0
begin
rollback transaction savePoint
end
end catch
end

GO
/****** Object:  StoredProcedure [dbo].[spInsertUser]    Script Date: 4.05.2021 13:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertUser]
@FullName nvarchar(50),
@Email nvarchar(50),
@PasswordHash varbinary(250),
@PasswordSalt varbinary(250),
@Roles nvarchar(75)
as
begin
insert into [dbo].Users(
[FullName],
[Email],
[PasswordHash],
[PasswordSalt],
[Roles])
values(@FullName,@Email,@PasswordHash,@PasswordSalt,@Roles)
select Id, FullName, Email, Roles from Users where Id = (SELECT SCOPE_IDENTITY())
End
--as 
GO
