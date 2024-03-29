USE [master]
GO
/****** Object:  Database [NET_NEW]    Script Date: 6/10/2023 2:03:39 PM ******/
CREATE DATABASE [NET_NEW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NET_NEW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\NET_NEW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NET_NEW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\NET_NEW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NET_NEW] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NET_NEW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NET_NEW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NET_NEW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NET_NEW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NET_NEW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NET_NEW] SET ARITHABORT OFF 
GO
ALTER DATABASE [NET_NEW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NET_NEW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NET_NEW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NET_NEW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NET_NEW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NET_NEW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NET_NEW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NET_NEW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NET_NEW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NET_NEW] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NET_NEW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NET_NEW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NET_NEW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NET_NEW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NET_NEW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NET_NEW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NET_NEW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NET_NEW] SET RECOVERY FULL 
GO
ALTER DATABASE [NET_NEW] SET  MULTI_USER 
GO
ALTER DATABASE [NET_NEW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NET_NEW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NET_NEW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NET_NEW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NET_NEW] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NET_NEW', N'ON'
GO
ALTER DATABASE [NET_NEW] SET QUERY_STORE = OFF
GO
USE [NET_NEW]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [NET_NEW]
GO
/****** Object:  UserDefinedFunction [dbo].[sf_DangNhapTaiKhoan]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[sf_DangNhapTaiKhoan] (@taikhoan_input varchar(30), @matkhau_input varchar(30)) 
RETURNS varchar(10)
AS
BEGIN
	DECLARE @MaTK varchar(10), @taikhoan varchar(30), @matkhau varchar(30)
	
	if(EXISTS(SELECT * FROM TAIKHOAN tk
		WHERE tk.TaiKhoan = @taikhoan_input))
	BEGIN
		SELECT @MaTK = tk.MaTK,@taikhoan = tk.TaiKhoan, @matkhau = tk.MatKhau
		FROM TAIKHOAN tk
		WHERE tk.TaiKhoan = @taikhoan_input
		if (@matkhau = @matkhau_input)
			return @MaTK		
		else
			return 'Sai mk';
	END
	ELSE
		return 'Sai tk';
	return 'Loi';
END
GO
/****** Object:  Table [dbo].[CONGVIEC]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONGVIEC](
	[MaCV] [varchar](10) NOT NULL,
	[TenCV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_CongViec]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[view_CongViec] as
select * from CONGVIEC
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [varchar](10) NOT NULL,
	[MaLuong] [varchar](10) NULL,
	[MaCV] [varchar](10) NULL,
	[MaTK] [varchar](10) NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Tuoi] [int] NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[QueQuan] [nvarchar](100) NULL,
	[SDT] [varchar](20) NOT NULL,
	[TrinhDoVH] [nvarchar](50) NOT NULL,
	[TrinhDoHV] [nvarchar](50) NOT NULL,
	[SoNamKN] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_NhanVien]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_NhanVien] as
select * from NHANVIEN
GO
/****** Object:  Table [dbo].[BANGLUONG]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANGLUONG](
	[MaLuong] [varchar](10) NOT NULL,
	[VaiTro] [nvarchar](50) NOT NULL,
	[LuongTheoGio] [real] NOT NULL,
	[HinhThuc] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_BangLuong]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_BangLuong] as
select * from BANGLUONG
GO
/****** Object:  Table [dbo].[THUCDON]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUCDON](
	[MaMon] [varchar](10) NOT NULL,
	[TenMon] [nvarchar](50) NULL,
	[TienNguyenLieu] [real] NOT NULL,
	[GiaTien] [real] NOT NULL,
	[DaBan] [int] NOT NULL,
	[ConLai] [int] NOT NULL,
	[anh] [nvarchar](255) NULL,
	[PhanLoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_ThucDon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_ThucDon] as
select * from THUCDON
GO
/****** Object:  Table [dbo].[GOIMON]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GOIMON](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[MaTK] [varchar](10) NULL,
	[MaMon] [varchar](10) NULL,
	[TongTien] [real] NOT NULL,
	[SoLuong] [int] NULL,
	[TrangThai] [varchar](15) NULL,
	[TgGoiMon] [datetime] NOT NULL,
	[TgGiao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_GoiMon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_GoiMon] as
select * from GOIMON
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[MaTK] [varchar](10) NOT NULL,
	[TaiKhoan] [varchar](30) NOT NULL,
	[MatKhau] [varchar](30) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[TinhTrang] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_TaiKhoan]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_TaiKhoan] as
select * from TAIKHOAN
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [varchar](10) NOT NULL,
	[MaTK] [varchar](10) NULL,
	[MaMay] [varchar](10) NULL,
	[MaMayCu] [varchar](10) NULL,
	[ThoiGianConLai] [bigint] NULL,
	[TienGio] [real] NULL,
	[TongThoiGian] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_KhachHang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_KhachHang] as
select * from KHACHHANG
GO
/****** Object:  Table [dbo].[KHACHHANGTHUONGXUYEN]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANGTHUONGXUYEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [varchar](10) NULL,
	[SoTienNap] [real] NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[NgaySinh] [datetime] NULL,
	[SDT] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_KHTX]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE View [dbo].[view_KHTX] as
select * from KHACHHANGTHUONGXUYEN
GO
/****** Object:  Table [dbo].[KHACHHANGVANGLAI]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANGVANGLAI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_KHVL]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[view_KHVL] as
select * from KHACHHANGVANGLAI
GO
/****** Object:  Table [dbo].[QUANTRI]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUANTRI](
	[MaQuanTri] [int] IDENTITY(1,1) NOT NULL,
	[MaTKAdmin] [varchar](10) NOT NULL,
	[MaTKKhachHang] [varchar](10) NOT NULL,
	[TgBatDau] [datetime] NOT NULL,
	[TgKetThuc] [datetime] NULL,
	[GhiChu] [varchar](100) NULL,
 CONSTRAINT [PK_QUANTRI_MaQuanTri] PRIMARY KEY CLUSTERED 
(
	[MaQuanTri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_QuanTri]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_QuanTri] as
select * from QUANTRI
GO
/****** Object:  Table [dbo].[QUANLYCONGVIEC]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUANLYCONGVIEC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](10) NULL,
	[NgayLamViec] [date] NULL,
	[CaLamViec] [nvarchar](10) NULL,
	[GioLamViec] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_QLCV]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_QLCV] as
select * from QUANLYCONGVIEC
GO
/****** Object:  Table [dbo].[MAYTINH]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAYTINH](
	[MaMay] [varchar](10) NOT NULL,
	[Hang] [varchar](20) NOT NULL,
	[TrangThai] [nvarchar](5) NULL,
	[GiaTien] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_MayTinh]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[view_MayTinh] as
select * from MAYTINH
GO
/****** Object:  View [dbo].[KhachHangGoiMon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[KhachHangGoiMon] AS
SELECT gm.STT, MaTk, td.MaMon, TenMon, GiaTien, SoLuong, TrangThai, TongTien, TgGoiMon, TgGiao
FROM GOIMON gm JOIN THUCDON td ON gm.MaMon = td.MaMon
GO
/****** Object:  View [dbo].[view_QuanLyMayTinhMayTinh]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_QuanLyMayTinhMayTinh]
AS
	SELECT mt.MaMay, mt.TrangThai, kh.MaKH, kh.MaTK FROM MAYTINH as mt 
	JOIN KHACHHANG as kh 
	ON mt.MaMay = kh.MaMay
GO
/****** Object:  Table [dbo].[TINNHAN]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINNHAN](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaQuanTri] [int] NOT NULL,
	[MaTKGui] [varchar](10) NULL,
	[MaTKNhan] [varchar](10) NULL,
	[NoiDung] [nvarchar](256) NULL,
	[TgGui] [datetime] NULL,
 CONSTRAINT [PK_TINHNAN_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BANGLUONG] ([MaLuong], [VaiTro], [LuongTheoGio], [HinhThuc]) VALUES (N'MaLuong001', N'Nhân viên', 14, N'Part-time')
INSERT [dbo].[BANGLUONG] ([MaLuong], [VaiTro], [LuongTheoGio], [HinhThuc]) VALUES (N'MaLuong002', N'Quản lí', 20, N'Full-time')
GO
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV]) VALUES (N'db001', N'Đầu bếp')
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV]) VALUES (N'kt001', N'Kỹ thuật')
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV]) VALUES (N'db002', N'Phụ bếp')
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV]) VALUES (N'qt001', N'Quản trị')
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV]) VALUES (N'tn001', N'Thu Ngân')
INSERT [dbo].[CONGVIEC] ([MaCV], [TenCV]) VALUES (N'vs001', N'Vệ Sinh')
GO
SET IDENTITY_INSERT [dbo].[GOIMON] ON 

INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (22, N'tk1', N'ma001', 10000, 2, N'Thu tien...', CAST(N'2022-11-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (23, N'tk1', N'ma001', 10000, 2, N'Thu tien...', CAST(N'2022-11-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (24, N'tk1', N'ma001', 10000, 2, N'Thu tien...', CAST(N'2022-11-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (25, N'tk1', N'ma001', 20000, 2, N'Done...', CAST(N'2022-11-30T00:00:00.000' AS DateTime), CAST(N'2022-11-30T13:33:30.687' AS DateTime))
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (26, N'tk1', N'ma001', 10000, 2, N'Done...', CAST(N'2022-11-30T00:00:00.000' AS DateTime), CAST(N'2022-11-30T14:13:21.530' AS DateTime))
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (27, N'tk1', N'ma001', 10000, 2, N'Thu tien...', CAST(N'2022-11-30T10:00:00.000' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (28, N'tk1', N'ma001', 10000, 2, N'Thu tien...', CAST(N'2022-11-30T10:10:00.000' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (34, N'tk1       ', N'ma002     ', 70000, 2, N'Done...', CAST(N'2022-12-01T09:14:39.000' AS DateTime), CAST(N'2022-12-01T23:02:18.700' AS DateTime))
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (35, N'tk1       ', N'ma002     ', 70000, 2, N'Dang nau...', CAST(N'2022-12-01T09:14:56.000' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (43, N'tk2       ', N'ma002     ', 70000, 2, N'Thu tien...', CAST(N'2022-12-01T09:24:48.387' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (44, N'tk2       ', N'ma002     ', 70000, 2, N'Thu tien...', CAST(N'2022-12-01T09:24:48.637' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (46, N'tk2       ', N'ma002     ', 35000, 1, N'Thu tien...', CAST(N'2022-12-01T09:31:35.620' AS DateTime), NULL)
INSERT [dbo].[GOIMON] ([STT], [MaTK], [MaMon], [TongTien], [SoLuong], [TrangThai], [TgGoiMon], [TgGiao]) VALUES (47, N'tk1       ', N'ma002     ', 70000, 2, N'Done...', CAST(N'2022-12-02T16:27:36.000' AS DateTime), CAST(N'2022-12-02T16:37:20.767' AS DateTime))
SET IDENTITY_INSERT [dbo].[GOIMON] OFF
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [MaTK], [MaMay], [MaMayCu], [ThoiGianConLai], [TienGio], [TongThoiGian]) VALUES (N'kh1', N'tk1', N'Vip001', N'Vip001', 3618, 7000, 7361)
INSERT [dbo].[KHACHHANG] ([MaKH], [MaTK], [MaMay], [MaMayCu], [ThoiGianConLai], [TienGio], [TongThoiGian]) VALUES (N'kh2', N'tk2', NULL, N'Thuong001', 7102, 7000, 917)
INSERT [dbo].[KHACHHANG] ([MaKH], [MaTK], [MaMay], [MaMayCu], [ThoiGianConLai], [TienGio], [TongThoiGian]) VALUES (N'kh3', N'tk3', NULL, N'Thuong001', 13888835, 7000, 187)
INSERT [dbo].[KHACHHANG] ([MaKH], [MaTK], [MaMay], [MaMayCu], [ThoiGianConLai], [TienGio], [TongThoiGian]) VALUES (N'kh4', N'tk4', NULL, NULL, 942390, 7000, 1200)
GO
SET IDENTITY_INSERT [dbo].[KHACHHANGTHUONGXUYEN] ON 

INSERT [dbo].[KHACHHANGTHUONGXUYEN] ([ID], [MaKH], [SoTienNap], [HoTen], [NgaySinh], [SDT]) VALUES (1, N'kh1', 0, NULL, NULL, NULL)
INSERT [dbo].[KHACHHANGTHUONGXUYEN] ([ID], [MaKH], [SoTienNap], [HoTen], [NgaySinh], [SDT]) VALUES (2, N'kh3', 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[KHACHHANGTHUONGXUYEN] OFF
GO
SET IDENTITY_INSERT [dbo].[KHACHHANGVANGLAI] ON 

INSERT [dbo].[KHACHHANGVANGLAI] ([ID], [MaKH]) VALUES (1, N'kh2')
SET IDENTITY_INSERT [dbo].[KHACHHANGVANGLAI] OFF
GO
INSERT [dbo].[MAYTINH] ([MaMay], [Hang], [TrangThai], [GiaTien]) VALUES (N'Thuong001', N'Asus', N'on', 10000)
INSERT [dbo].[MAYTINH] ([MaMay], [Hang], [TrangThai], [GiaTien]) VALUES (N'Thuong002', N'Acer', N'on', 10000)
INSERT [dbo].[MAYTINH] ([MaMay], [Hang], [TrangThai], [GiaTien]) VALUES (N'Vip001', N'Dell', N'on', 10000)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [MaLuong], [MaCV], [MaTK], [HoTen], [Tuoi], [GioiTinh], [QueQuan], [SDT], [TrinhDoVH], [TrinhDoHV], [SoNamKN]) VALUES (N'db001', N'maluong001', N'db001', N'db1', N'Dau Bep 1', 20, N'Nam', N'THCM', N'04444444444', N'DH', N'DH', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [MaLuong], [MaCV], [MaTK], [HoTen], [Tuoi], [GioiTinh], [QueQuan], [SDT], [TrinhDoVH], [TrinhDoHV], [SoNamKN]) VALUES (N'qt001', N'maluong001', N'qt001', N'ad1', N'Admin 1', 20, N'Nam', N'TPHCM', N'03333333333', N'DH', N'DH', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [MaLuong], [MaCV], [MaTK], [HoTen], [Tuoi], [GioiTinh], [QueQuan], [SDT], [TrinhDoVH], [TrinhDoHV], [SoNamKN]) VALUES (N'tn001', N'maluong001', N'tn001', N'tn1', N'Thu Ngan 1', 21, N'Nam', N'TPHCM', N'0111111111', N'DH', N'DH', 3)
INSERT [dbo].[NHANVIEN] ([MaNV], [MaLuong], [MaCV], [MaTK], [HoTen], [Tuoi], [GioiTinh], [QueQuan], [SDT], [TrinhDoVH], [TrinhDoHV], [SoNamKN]) VALUES (N'tn002', N'maluong001', N'tn001', N'tn2', N'Thu Ngan 2', 18, N'Nu', N'blabla', N'0987654321', N'DH', N'DH', 4)
INSERT [dbo].[NHANVIEN] ([MaNV], [MaLuong], [MaCV], [MaTK], [HoTen], [Tuoi], [GioiTinh], [QueQuan], [SDT], [TrinhDoVH], [TrinhDoHV], [SoNamKN]) VALUES (N'tn003', N'maluong001', N'tn001', N'tn3', N'Thu Ngan 3', 18, N'Nam', N'TPHCM', N'0987654320', N'DH', N'DH', 2)
INSERT [dbo].[NHANVIEN] ([MaNV], [MaLuong], [MaCV], [MaTK], [HoTen], [Tuoi], [GioiTinh], [QueQuan], [SDT], [TrinhDoVH], [TrinhDoHV], [SoNamKN]) VALUES (N'vs001', N'maluong001', N'vs001', N'vs1', N'Ve Sinh 1', 20, N'Nu', N'TPHCM', N'02222222222', N'DH', N'DH', 3)
GO
SET IDENTITY_INSERT [dbo].[QUANLYCONGVIEC] ON 

INSERT [dbo].[QUANLYCONGVIEC] ([ID], [MaNV], [NgayLamViec], [CaLamViec], [GioLamViec]) VALUES (1, N'tn001', CAST(N'2022-10-18' AS Date), N'13h-21h', 8)
INSERT [dbo].[QUANLYCONGVIEC] ([ID], [MaNV], [NgayLamViec], [CaLamViec], [GioLamViec]) VALUES (2, N'vs001', CAST(N'2022-10-18' AS Date), N'13h-21h', 8)
SET IDENTITY_INSERT [dbo].[QUANLYCONGVIEC] OFF
GO
SET IDENTITY_INSERT [dbo].[QUANTRI] ON 

INSERT [dbo].[QUANTRI] ([MaQuanTri], [MaTKAdmin], [MaTKKhachHang], [TgBatDau], [TgKetThuc], [GhiChu]) VALUES (1210, N'tn1', N'tk3', CAST(N'2022-12-02T15:34:13.077' AS DateTime), CAST(N'2022-12-02T15:34:21.070' AS DateTime), NULL)
INSERT [dbo].[QUANTRI] ([MaQuanTri], [MaTKAdmin], [MaTKKhachHang], [TgBatDau], [TgKetThuc], [GhiChu]) VALUES (1211, N'tn1', N'tk1', CAST(N'2022-12-02T15:42:10.000' AS DateTime), CAST(N'2022-12-02T15:42:48.447' AS DateTime), NULL)
INSERT [dbo].[QUANTRI] ([MaQuanTri], [MaTKAdmin], [MaTKKhachHang], [TgBatDau], [TgKetThuc], [GhiChu]) VALUES (1212, N'tn1', N'tk2', CAST(N'2022-12-02T15:42:12.197' AS DateTime), CAST(N'2022-12-02T15:42:49.560' AS DateTime), NULL)
INSERT [dbo].[QUANTRI] ([MaQuanTri], [MaTKAdmin], [MaTKKhachHang], [TgBatDau], [TgKetThuc], [GhiChu]) VALUES (1213, N'tn1', N'tk1', CAST(N'2022-12-02T15:47:26.650' AS DateTime), CAST(N'2022-12-02T15:48:34.870' AS DateTime), NULL)
INSERT [dbo].[QUANTRI] ([MaQuanTri], [MaTKAdmin], [MaTKKhachHang], [TgBatDau], [TgKetThuc], [GhiChu]) VALUES (1214, N'tn1', N'tk2', CAST(N'2022-12-02T15:47:28.327' AS DateTime), CAST(N'2022-12-02T15:48:36.350' AS DateTime), NULL)
INSERT [dbo].[QUANTRI] ([MaQuanTri], [MaTKAdmin], [MaTKKhachHang], [TgBatDau], [TgKetThuc], [GhiChu]) VALUES (1215, N'tn1', N'tk1', CAST(N'2022-12-02T16:16:42.880' AS DateTime), CAST(N'2022-12-02T16:16:49.350' AS DateTime), NULL)
INSERT [dbo].[QUANTRI] ([MaQuanTri], [MaTKAdmin], [MaTKKhachHang], [TgBatDau], [TgKetThuc], [GhiChu]) VALUES (1216, N'tn1', N'tk1', CAST(N'2022-12-02T16:27:27.130' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[QUANTRI] OFF
GO
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'ad1', N'admin1', N'ad1', CAST(N'2022-10-18' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'ad2', N'admin2', N'ad2', CAST(N'2022-12-01' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'db1', N'daubep1', N'db1', CAST(N'2022-11-30' AS Date), N'on')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'tk1', N'tk1', N'tk1', CAST(N'2022-10-18' AS Date), N'on')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'tk2', N'tk2', N'tk2', CAST(N'2022-10-18' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'tk3', N'tk3', N'tk3', CAST(N'2022-11-25' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'tk4', N'tk4', N'tk4', CAST(N'2022-12-01' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'tn1', N'thungan1', N'tn1', CAST(N'2022-10-18' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'tn2', N'thungan2', N'tn1', CAST(N'2022-12-01' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'tn3', N'thungan3', N'tn3', CAST(N'2022-12-01' AS Date), N'off')
INSERT [dbo].[TAIKHOAN] ([MaTK], [TaiKhoan], [MatKhau], [NgayTao], [TinhTrang]) VALUES (N'vs1', N'vesinh1', N'vs1', CAST(N'2022-10-18' AS Date), N'off')
GO
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'ma001', N'Mì tôm', 10000, 25000, 14, 36, N'images\mitom.png', N'Mì tôm')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'ma002', N'Cá viên', 20000, 35000, 13, 37, N'images\cavien.png', N'Ăn vặt')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'ma003', N'Gà viên', 10000, 25000, 10, 50, N'images\string.png', N'Ăn vặt')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'ma004', N'Cơm chiên', 10000, 25000, 9, 50, N'images\string.png', N'Cơm')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu001', N'Pepsi', 6000, 12000, 8, 50, N'images\pepsi.png', N'Nước giải khát')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu002', N'Cocacola', 6000, 12000, 7, 50, N'images\cocacola.png', N'Nước giải khát')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu003', N'Sting Dâu', 6000, 12000, 7, 50, N'images\string.png', N'Nước giải khát')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu004', N'Redbull', 8000, 15000, 8, 50, N'images\string.png', N'Nước giải khát')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu005', N'Sting Gold', 6000, 12000, 9, 50, N'images\string.png', N'Nước giải khát')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu006', N'Cà phê sữa', 6000, 15000, 10, 50, N'image\caphesua.png', N'Cà phê')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu007', N'Trà sữa truyền thống', 10000, 20000, 2, 50, N'image\trasuatruyenthong.png', N'Trà sữa')
INSERT [dbo].[THUCDON] ([MaMon], [TenMon], [TienNguyenLieu], [GiaTien], [DaBan], [ConLai], [anh], [PhanLoai]) VALUES (N'nu008', N'Trà sữa thái xanh', 10000, 21000, 0, 5, NULL, N'Trà s?a')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BANGLUON__4A1D98242A4A9914]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[BANGLUONG] ADD UNIQUE NONCLUSTERED 
(
	[VaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BANGLUON__4A1D98243D67334E]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[BANGLUONG] ADD UNIQUE NONCLUSTERED 
(
	[VaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BANGLUON__4A1D982471B9641A]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[BANGLUONG] ADD UNIQUE NONCLUSTERED 
(
	[VaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__CONGVIEC__4CF92206A7F54490]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[CONGVIEC] ADD UNIQUE NONCLUSTERED 
(
	[TenCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_KHACHHANG]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[KHACHHANG] ADD  CONSTRAINT [UC_KHACHHANG] UNIQUE NONCLUSTERED 
(
	[MaMay] ASC,
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NHANVIEN__CA1930A5756AC386]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[NHANVIEN] ADD UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TAIKHOAN__D5B8C7F00C8481FE]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[TAIKHOAN] ADD UNIQUE NONCLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TAIKHOAN__D5B8C7F0220B3D21]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[TAIKHOAN] ADD UNIQUE NONCLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TAIKHOAN__D5B8C7F03807ACDA]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[TAIKHOAN] ADD UNIQUE NONCLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TAIKHOAN__D5B8C7F056F1A475]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[TAIKHOAN] ADD UNIQUE NONCLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__THUCDON__332EF565B6B142A1]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[THUCDON] ADD UNIQUE NONCLUSTERED 
(
	[TenMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__THUCDON__332EF565C1DBB5D7]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[THUCDON] ADD UNIQUE NONCLUSTERED 
(
	[TenMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__THUCDON__332EF565C5FA6C2F]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[THUCDON] ADD UNIQUE NONCLUSTERED 
(
	[TenMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__THUCDON__332EF565CFA0CF6D]    Script Date: 6/10/2023 2:03:39 PM ******/
ALTER TABLE [dbo].[THUCDON] ADD UNIQUE NONCLUSTERED 
(
	[TenMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GOIMON]  WITH CHECK ADD FOREIGN KEY([MaMon])
REFERENCES [dbo].[THUCDON] ([MaMon])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[GOIMON]  WITH CHECK ADD FOREIGN KEY([MaTK])
REFERENCES [dbo].[TAIKHOAN] ([MaTK])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD FOREIGN KEY([MaMay])
REFERENCES [dbo].[MAYTINH] ([MaMay])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD FOREIGN KEY([MaTK])
REFERENCES [dbo].[TAIKHOAN] ([MaTK])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KHACHHANGTHUONGXUYEN]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KHACHHANGVANGLAI]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([MaCV])
REFERENCES [dbo].[CONGVIEC] ([MaCV])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([MaLuong])
REFERENCES [dbo].[BANGLUONG] ([MaLuong])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([MaTK])
REFERENCES [dbo].[TAIKHOAN] ([MaTK])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[QUANLYCONGVIEC]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[QUANTRI]  WITH CHECK ADD  CONSTRAINT [FK_QUANTRI_TAIKHOAN_MaTKAdmin] FOREIGN KEY([MaTKAdmin])
REFERENCES [dbo].[TAIKHOAN] ([MaTK])
GO
ALTER TABLE [dbo].[QUANTRI] CHECK CONSTRAINT [FK_QUANTRI_TAIKHOAN_MaTKAdmin]
GO
ALTER TABLE [dbo].[QUANTRI]  WITH CHECK ADD  CONSTRAINT [FK_QUANTRI_TAIKHOAN_MaTKKhachHang] FOREIGN KEY([MaTKKhachHang])
REFERENCES [dbo].[TAIKHOAN] ([MaTK])
GO
ALTER TABLE [dbo].[QUANTRI] CHECK CONSTRAINT [FK_QUANTRI_TAIKHOAN_MaTKKhachHang]
GO
ALTER TABLE [dbo].[TINNHAN]  WITH CHECK ADD  CONSTRAINT [FK_TINNHAN_QUANTRI_MaQuanTri] FOREIGN KEY([MaQuanTri])
REFERENCES [dbo].[QUANTRI] ([MaQuanTri])
GO
ALTER TABLE [dbo].[TINNHAN] CHECK CONSTRAINT [FK_TINNHAN_QUANTRI_MaQuanTri]
GO
/****** Object:  StoredProcedure [dbo].[sp_BangLuongLoad]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_BangLuongLoad] (@matk varchar(10))
as
begin tran
	if(@matk is null)
		begin
			raiserror('Khong duoc bo trong',16,1)
			rollback
			return
		end
	select * from BANGLUONG as bl join NHANVIEN as nv on bl.MaLuong = nv.MaLuong where nv.MaTK = @matk
	commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatMaMayChoKHACHHANG]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_CapNhatMaMayChoKHACHHANG](@MaKH varchar(10), @MaMay varchar(10))
AS 
BEGIN
	UPDATE KHACHHANG
	SET MaMay = @MaMay
	WHERE MaKH = @MaKH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DangXuatTaiKhoan]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DangXuatTaiKhoan](@MaTK varchar(10))
AS
BEGIN
	/* off Tình Trạng Tài khoản */
	UPDATE TAIKHOAN
	SET TinhTrang='off'
	WHERE MaTK=@MaTK
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongNhanVien]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_HoatDongNhanVien](@maTK varchar(10))
as
begin tran
		declare @manv varchar(10)
		select @manv = MaNV from NHANVIEN where MaTK = @maTK
		if(@manv is null)
		begin
			raiserror('Khong duoc bo trong',16,1)
			rollback
			return
		end
	select * from QUANLYCONGVIEC where MaNV = @manv
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHangDoiMatKhau]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_KhachHangDoiMatKhau]
(@MaTK char(10), @matkhaucu varchar(30), @matkhaumoi varchar(30))
AS
BEGIN
	DECLARE @matkhau varchar(30)

	SELECT @matkhau = tk.MatKhau
	FROM TAIKHOAN tk
	WHERE tk.MaTK = @MaTK

	BEGIN TRAN

	IF (@matkhau IS NULL)
	BEGIN
		RAISERROR('Mat khau rong', 16, 1)
		ROLLBACK
		RETURN
	END
	ELSE 
	BEGIN
		IF (@matkhau = @matkhaucu)
			BEGIN
				UPDATE TAIKHOAN 
				SET MatKhau = @matkhaumoi
				WHERE TAIKHOAN.MaTK = @MaTK
			END
		ELSE
			BEGIN
				RAISERROR('Sai mat khau', 16, 1)
				ROLLBACK
				RETURN 
			END
	END
	COMMIT TRAN
END

GO
/****** Object:  StoredProcedure [dbo].[sp_KhachHangGoiMon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_KhachHangGoiMon]
(@MaTK varchar(10), @MaMon varchar(10), @soluong int)
AS
BEGIN
	DECLARE @giatien real, @SoLuongConLai int

	SELECT @giatien = td.GiaTien, @SoLuongConLai = td.ConLai 
	FROM THUCDON td
	WHERE td.MaMon = @MaMon

	BEGIN TRAN

	IF (@giatien IS NULL)
	BEGIN
		RAISERROR('Khong tim thay mon an trong Thuc Don', 16, 1)
		ROLLBACK
		RETURN
	END
	ELSE
	BEGIN
		IF (@SoLuongConLai>@soluong)
		BEGIN
			INSERT INTO GOIMON (MaTK, MaMon, TongTien, TrangThai, SoLuong, TgGoiMon)
			VALUES (@MaTK, @MaMon, @soluong*@giatien, 'Thu tien...', @soluong,GETDATE())
			
		END
		ELSE
		BEGIN
			RAISERROR('Khong con du mon an trong Thuc Don', 16, 1)
			ROLLBACK 
			RETURN
		END
	END
	COMMIT TRAN
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Login](@taiKhoan varchar(50), @matKhau varchar(50))
as
begin tran
	if(@taiKhoan is null or @matKhau is null)
		begin
			raiserror('Khong duoc bo trong',16,1)
			rollback
			return
		end
	declare @status varchar(10), @maCV varchar(10), @maTK varchar(10)
	if exists( select * from TAIKHOAN as tk join NHANVIEN as nv on tk.MaTK = nv.MaTK where tk.TaiKhoan = @taiKhoan and tk.MatKhau = @matKhau)
	begin
		select @maCV = MaCV, @maTK = tk.MaTK from TAIKHOAN as tk join NHANVIEN as nv on tk.MaTK = nv.MaTK where tk.TaiKhoan = @taiKhoan and tk.MatKhau = @matKhau
		if (CHARINDEX('qt', @maCV) != 0)
			set @status = @maTK
		else
			select @status = tk.MaTK from TAIKHOAN as tk where tk.TaiKhoan = @taiKhoan and tk.MatKhau = @matKhau
	end
	else
		set @status = 'none'
	select @status
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_LuongThangNhanVien]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LuongThangNhanVien](@matk varchar(10))
as
begin tran
		declare @maNV varchar(30)
		select @maNV = nv.MaNV from NHANVIEN as nv where nv.MaTK = @maTK
		if(@maNV is null)
		begin
			raiserror('Khong duoc bo trong',16,1)
			rollback
			return
		end
	select  MONTH(NgayLamViec) as Thang , SUM(GioLamViec*LuongTheoGio) as LuongThang  from QUANLYCONGVIEC as qlcv join NHANVIEN as nv on qlcv.MaNV = nv.MaNV join BANGLUONG as bl on nv.MaLuong = bl.MaLuong where nv.MaNV = @maNV group by Month(NgayLamViec)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_LuongThangNhanVienAll]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LuongThangNhanVienAll]
as
begin
	select nv.MaNV , MONTH(NgayLamViec) as Thang , SUM(GioLamViec*LuongTheoGio) as LuongThang  from QUANLYCONGVIEC as qlcv join NHANVIEN as nv on qlcv.MaNV = nv.MaNV join BANGLUONG as bl on nv.MaLuong = bl.MaLuong  group by MONTH(NgayLamViec), nv.MaNV
end
GO
/****** Object:  StoredProcedure [dbo].[sp_NapTienChoKhachHang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_NapTienChoKhachHang](@maKH varchar(10), @soTien bigint)
AS
BEGIN
	update KHACHHANG
	SET ThoiGianConLai = ThoiGianConLai + Cast((@soTien/TienGio) as float)*3600,
	TongThoiGian = TongThoiGian + Cast((@soTien/TienGio) as float)*3600
	WHERE MaKH = @maKH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_NhanVienLoad]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_NhanVienLoad] (@maNV varchar(50))
as
begin tran
	if(@maNV is null)
		begin
			raiserror('Khong duoc bo trong',16,1)
			rollback
			return
		end
	select * from NHANVIEN as nv join TAIKHOAN as tk on nv.MaTK = tk.MaTK where tk.MaTK = @maNV
	commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchNhanVien]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_SearchNhanVien](@maNV varchar(10))
as
begin
	select * from NHANVIEN where MaNV = @maNV
end
GO
/****** Object:  StoredProcedure [dbo].[sp_sinhKhachHangVangLai]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_sinhKhachHangVangLai]
AS
BEGIN TRAN
		DECLARE @matk varchar(30),
				@taikhoan varchar(30), 
				@matkhau varchar(30),
				@ngaytao datetime,
				@tinhtrang varchar(30),
				@soluongcombohientai int,
				@soluongtaikhoanhientai int
		--Sinh matk
		SELECT @soluongtaikhoanhientai = count(tk.MaTK)
		FROM TAIKHOAN as tk
		WHERE CHARINDEX('tk', tk.MaTK) != 0
		SET @matk = CONCAT('tk',@soluongtaikhoanhientai+1)
		--Sinh taikhoan
		SELECT @soluongcombohientai = count(khvl.MaKH)
		FROM KHACHHANGVANGLAI as khvl
		WHERE CHARINDEX('COMBO',khvl.MaKH) != 0
		SET @taikhoan = CONCAT('COMBO',@soluongcombohientai+1)
		--Sinh matkhau
		DECLARE @index INT = 0;
		WHILE @index < 4 
		BEGIN
			SET @matkhau = CONCAT(@matkhau, CAST(RAND()*(10) as INT))
			SET @index = @index + 1
		END 
		--Sinh ngaytao
		SET @ngaytao = GETDATE()
		--Sinh tinhtrang
		SET @tinhtrang = 'off'

		----INSERT VAO BANG TAIKHOAN
		--INSERT INTO TAIKHOAN 
		--VALUES (@matk, @taikhoan, @matkhau, @ngaytao, @tinhtrang)

		--DECLARE @makh varchar(10),
				


		PRINT(@matk)
		PRINT(@taikhoan)
		PRINT(@matkhau)
		PRINT(@ngaytao)
		PRINT(@tinhtrang)



COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaBangLuong]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaBangLuong] (@maLuong varchar(10), @vaiTro nvarchar(50), @luongTheoGio real, @hinhThuc nvarchar(50))
as
begin tran
if(@maLuong is null or @vaiTro is null or @luongTheoGio is null or @hinhThuc is null)
		begin
			raiserror('Khong duoc bo trong!', 16,1)
			rollback
			return
		end
	update BANGLUONG set VaiTro = @vaiTro, LuongTheoGio = @luongTheoGio, HinhThuc= @hinhThuc where MaLuong = @maLuong
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaCongViec]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_SuaCongViec] (@maCV varchar (10), @tenCV nvarchar(50))
as
begin tran
	if(@maCV is null or @tenCV is null)
		begin
			raiserror('Khong duoc bo trong!', 16,1)
			rollback
			return
		end
	update CONGVIEC set TenCV = @tenCV where MaCV = @maCV
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaGoiMon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaGoiMon](@stt int, @maTK varchar(10), @maMon varchar(10), @tongTien real, @soLuong int, @trangThai varchar(15), 
@tgGoiMon datetime, @tgGiao datetime)
as
begin tran
	if(@maTK is null or @maMon is null or  @tongTien is null or @soLuong is null or @trangThai is null or @tgGoiMon is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update GOIMON set MaTK = @maTK, MaMon = @maMon, TongTien = @tongTien, SoLuong = @soLuong, TrangThai = @trangThai, TgGoiMon = @tgGoiMon, TgGiao = TgGiao
	where stt = @stt
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaKhachHang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_SuaKhachHang](@maKH varchar(10), @maTK varchar(10), @maMay varchar(10),  @maMayCu varchar(10), @thoiGianConLai float
, @tienGio float, @tongThoiGian float )
as
begin tran
	if(@maKH is null or @maTK is null )
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update KHACHHANG set MaTK = @maTK, MaMay = @maMay,  MaMayCu = @maMayCu, ThoiGianConLai = @thoiGianConLai, TienGio = @tienGio, TongThoiGian = @tongThoiGian
	where MaKH = @maKH
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaKHTX]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaKHTX](@id int, @maKH varchar(10), @maUuDai varchar(10), @soTienNap float, @hoTen [nvarchar](100),
	@ngaySinh [datetime],
	@sdt [nvarchar](10))
as
begin tran
	if(@maKH is null or @soTienNap is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update KHACHHANGTHUONGXUYEN set MaKH = @maKH, MaUuDai = @maUuDai, SoTienNap = @soTienNap, HoTen = @hoTen, NgaySinh = @ngaySinh, SDT = @sdt
	where id = @id
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaKHVL]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaKHVL](@id int ,@maKH varchar(10))
as
begin tran
	if(@maKH is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update KHACHHANGVANGLAI set MaKH = @maKH
	where id=@id
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaMayTinh]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaMayTinh](@maMay varchar(10), @hang varchar(20), @trangThai varchar(5), @giaTien int)
as
begin tran
	if(@maMay is null or @hang is null or @trangThai is null or @giaTien is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update MAYTINH set Hang = @hang, TrangThai = @trangThai, GiaTien = @giaTien
	where MaMay = @maMay
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaNhanVien]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaNhanVien](@maNV varchar(10),@maLuong varchar(10), @maCV varchar(10), @maTk varchar(10), 
@hoTen nvarchar(50), @tuoi int, @gioiTinh nvarchar(5), @queQuan nvarchar(100), 
@sdt varchar(20), @trinhDoVH nvarchar(50), @trinhDoHV nvarchar(50), @soNamKN int)
as
begin tran
	if(@maNV is null or @maLuong is null or @maCV is null or @maTk is null or 
	@hoTen is null or @tuoi is null or @gioiTinh is null or @queQuan is null or 
	@sdt is null or @trinhDoVH is null or @trinhDoHV is null or @soNamKN is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update NHANVIEN set MaLuong = @maLuong, MaCV = @maCV, MaTK = @maTk,
	HoTen = @hoTen, tuoi =  @tuoi, GioiTinh =  @gioiTinh, QueQuan = @queQuan,
	SDT = @sdt, TrinhDoVH = @trinhDoVH, TrinhDoHV = @trinhDoHV, SoNamKN = @soNamKN
	where MaNV = @maNV
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaQLCV]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaQLCV](@id int, @maNV varchar(10), @ngayLamViec date , @caLamViec nvarchar(10), @gioLamViec int)
as
begin tran
	if(@maNV is null or @ngayLamViec is null or @caLamViec is null or @gioLamViec is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update QUANLYCONGVIEC set MaNV = @maNV ,NgayLamViec = @ngayLamViec,CaLamViec = @caLamViec, GioLamViec = @gioLamViec
	where id = @id
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaQuanTri]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaQuanTri](@maQuanTri varchar(10), @maTKAdmin varchar(10), @maTKKhachHang varchar(10), @tgBatDau datetime, @tgKetThuc datetime,
@ghiChu varchar(10))
as 
begin tran
	if(@maTKAdmin is null or @maTKKhachHang is null or @tgBatDau is null or @maQuanTri is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update QUANTRI set MaTKAdmin = @maTKAdmin, MaTKKhachHang = @maTKKhachHang, TgBatDau=  @tgBatDau, TgKetThuc = @tgKetThuc, 
	GhiChu = @ghiChu
	where MaQuanTri = @maQuanTri
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaTaiKhoan]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaTaiKhoan] (@maTK varchar(10), @taiKhoan varchar(30), @matKhau varchar(30), @ngayTao date, @tinhTrang varchar(30))
as
begin tran
	if(@maTK is null or @taiKhoan is null or @matKhau is null or @ngayTao is null or @tinhTrang is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update TAIKHOAN set TaiKhoan = @taiKhoan, MatKhau = @matKhau, NgayTao = @ngayTao, TinhTrang = @tinhTrang
	where MaTK = @maTK
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_SuaThucDon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_SuaThucDon](@maMon varchar(10), @tenMon nvarchar(20), @tienNguyenLieu real, @giaTien real, @daBan int, @conLai int,
@anh nvarchar(255),
	@PhanLoai nvarchar(50))
as
begin tran
	if(@maMon is null or @tenMon is null or @tienNguyenLieu is null or @giaTien is null or @daBan is null or @conLai is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	update THUCDON set TenMon = @tenMon, TienNguyenLieu = @tienNguyenLieu, GiaTien = @giaTien, DaBan = @daBan, ConLai = @conLai, anh = @anh, PhanLoai = @PhanLoai
	where MaMon = @maMon
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_TaiKhoanLoad]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_TaiKhoanLoad](@maTK varchar(10))
as
begin tran
		if(@maTK is null)
		begin
			raiserror('Khong duoc bo trong',16,1)
			rollback
			return
		end
	select tk.MaTK, tk.TaiKhoan, tk.MatKhau, tk.NgayTao, tk.TinhTrang from NHANVIEN as nv join TAIKHOAN as tk on nv.MaTK = tk.MaTK where nv.MaTK = @maTK
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemBangLuong]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_ThemBangLuong] (@maLuong varchar(10), @vaiTro nvarchar(50), @luongTheoGio real, @hinhThuc nvarchar(50))
as
begin tran
	if(@maLuong is null or @vaiTro is null or @luongTheoGio is null or @hinhThuc is null)
		begin
			raiserror('Khong duoc bo trong!', 16,1)
			rollback
			return
		end
	insert into BANGLUONG values(@maLuong, @vaiTro, @luongTheoGio, @hinhThuc)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemCongViec]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_ThemCongViec] (@maCV varchar(10), @tenCV nvarchar(50))
as
begin tran
	if(@maCV is null or @tenCV is null)
		begin
			raiserror('Khong duoc bo trong!', 16,1)
			rollback
			return
		end
	Insert into CONGVIEC values (@maCV, @tenCV)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemGoiMon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_ThemGoiMon](@maTK varchar(10), @maMon varchar(10), @tongTien real, @soLuong int, @trangThai varchar(15),
@tgGoiMon datetime, @tgGiao datetime)
as
begin tran
	if(@maTK is null or @maMon is null or  @tongTien is null or @soLuong is null or @trangThai is null or @tgGoiMon is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into GOIMON values (@maTK, @maMon, @tongTien, @soLuong, @trangThai, @tgGoiMon, @tgGiao)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKhachHang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ThemKhachHang](@maKH varchar(10), @maTK varchar(10), @maMay varchar(10),  @maMayCu varchar(10),
@thoiGianConLai float, @tienGio [real],
	@tongThoiGian [float])
as
begin tran
	if(@maKH is null or @maTK is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into KHACHHANG values(@maKH, @maTK, @maMay, @maMayCu, @thoiGianConLai, @tienGio, @tongThoiGian)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKHTX]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ThemKHTX](@maKH varchar(10), @maUuDai varchar(10), @soTienNap float, @hoTen [nvarchar](100),
	@ngaySinh [datetime],
	@sdt [nvarchar](10))
as
begin tran
	if(@maKH is null or @soTienNap is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into KHACHHANGTHUONGXUYEN values (@maKH, @maUuDai, @soTienNap, @hoTen, @ngaySinh, @sdt)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKHVL]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_ThemKHVL](@maKH varchar(10))
as
begin tran
	if(@maKH is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into KHACHHANGVANGLAI values(@maKH)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemMayTinh]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_ThemMayTinh](@maMay varchar(10), @hang varchar(20), @trangThai varchar(5), @giaTien int)
as
begin tran
	if(@maMay is null or @hang is null or @trangThai is null or @giaTien is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into MAYTINH values (@maMay, @hang, @trangThai, @giaTien)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNhanVien]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_ThemNhanVien](@maNV varchar(10),@maLuong varchar(10), @maCV varchar(10), @maTk varchar(10), 
@hoTen nvarchar(50), @tuoi int, @gioiTinh nvarchar(5), @queQuan nvarchar(100), 
@sdt varchar(20), @trinhDoVH nvarchar(50), @trinhDoHV nvarchar(50), @soNamKN int)
as
begin tran
	if(@maNV is null or @maLuong is null or @maCV is null or @maTk is null or 
	@hoTen is null or @tuoi is null or @gioiTinh is null or @queQuan is null or 
	@sdt is null or @trinhDoVH is null or @trinhDoHV is null or @soNamKN is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into NHANVIEN values (@maNV, @maLuong, @maCV, @maTk, @hoTen, @tuoi, @gioiTinh, @queQuan, @sdt, @trinhDoVH, @trinhDoHV, @soNamKN)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemQLCV]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_ThemQLCV](@maNV varchar(10), @ngayLamViec date , @caLamViec nvarchar(10), @gioLamViec int)
as
begin tran
	if(@maNV is null or @ngayLamViec is null or @caLamViec is null or @gioLamViec is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into QUANLYCONGVIEC values (@maNV, @ngayLamViec, @caLamViec, @gioLamViec)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemQuanTri]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_ThemQuanTri] (@maTKAdmin varchar(10), @maTKKhachHang varchar(10), @tgBatDau datetime, @tgKetThuc datetime,
@ghiChu varchar(10))
as 
begin tran
	if(@maTKAdmin is null or @maTKKhachHang is null or @tgBatDau is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into QUANTRI values (@maTKAdmin, @maTKKhachHang, @tgBatDau, @tgKetThuc, @ghiChu)

commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemTaiKhoan]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_ThemTaiKhoan] (@maTK varchar(10), @taiKhoan varchar(30), @matKhau varchar(30), @ngayTao date, @tinhTrang varchar(30))
as
begin tran
	if(@maTK is null or @taiKhoan is null or @matKhau is null or @ngayTao is null or @tinhTrang is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into TAIKHOAN values(@maTK, @taiKhoan, @matKhau, @ngayTao, @tinhTrang)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemThucDon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_ThemThucDon](@maMon varchar(10), @tenMon nvarchar(20), @tienNguyenLieu real, @giaTien real, @daBan int, @conLai int, @anh [nvarchar](255),
@phanLoai [nvarchar](50))
as
begin tran
	if(@maMon is null or @tenMon is null or @tienNguyenLieu is null or @giaTien is null or @daBan is null or @conLai is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	insert into THUCDON values (@maMon, @tenMon, @tienNguyenLieu, @giaTien, @daBan, @conLai, @anh, @phanLoai)
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaBangLuong]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaBangLuong] (@maLuong varchar(10))
as
begin tran
if(@maLuong is null)
		begin
			raiserror('Khong duoc bo trong!', 16,1)
			rollback
			return
		end
	delete from BANGLUONG where MaLuong = @maLuong
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaCongViec]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_XoaCongViec] (@maCV varchar(10))
as 
begin tran
	if(@maCV is null)
		begin
			raiserror('Khong duoc bo trong!', 16,1)
			rollback
			return
		end
	delete from CONGVIEC where MaCV = @maCV
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaGoiMon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaGoiMon](@stt int)
as
begin tran
	if(@stt is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from GOIMON where stt = @stt
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaKhachHang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaKhachHang](@maKH varchar(10))
as
begin tran
	if(@maKH is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from KHACHHANG where MaKH = @maKH
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaKHTX]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaKHTX](@id int)
as
begin tran
	if(@id is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete  from KHACHHANGTHUONGXUYEN where id = @id
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaKHVL]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaKHVL](@id int)
as
begin tran
	if(@id is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from KHACHHANGVANGLAI where id = @id
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaMayTinh]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_XoaMayTinh](@maMay varchar(10))
as
begin tran
	if(@maMay is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from MAYTINH where MaMay = @maMay
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaNhanVien]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaNhanVien](@maNV varchar(10))
as
begin tran
	if(@maNV is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete NHANVIEN where MaNV = @maNV
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaQLCV]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaQLCV](@id int)
as
begin tran
	if(@id is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from QUANLYCONGVIEC where id = @id
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaQuanTri]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaQuanTri](@maQuanTri varchar(10))
as 
begin tran
	if(@maQuanTri is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from QUANTRI where MaQuanTri = @maQuanTri
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaTaiKhoan]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaTaiKhoan] (@maTK varchar(10))
as
begin tran
	if(@maTK is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from TAIKHOAN where matk = @maTK
commit tran
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaThucDon]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_XoaThucDon](@maMon varchar(10))
as
begin tran
	if(@maMon is null)
		begin
			raiserror('Khong duoc bo trong!',16,1)
			rollback
			return
		end
	delete from THUCDON where MaMon = @maMon
commit tran
GO
/****** Object:  StoredProcedure [dbo].[ThongKeChiPhiDATU]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[ThongKeChiPhiDATU]
as
begin	
 
select  PhanLoai ,Sum(DaBan * GiaTien) as TongThu, Sum((DaBan+ConLai)*TienNguyenLieu) as TongChi, Sum((DaBan * GiaTien) -(DaBan+ConLai)*TienNguyenLieu) as LoiNhuan
from THUCDON group by PhanLoai

end
GO
/****** Object:  StoredProcedure [dbo].[ThongKeChiPhiDATU_Thang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ThongKeChiPhiDATU_Thang] (@thang varchar(10))
as
begin tran	
if(@thang is null)
	begin
			raiserror('Khong duoc bo trong!', 16,1)
			rollback
			return
		end
if(@thang % 2 != 0)
begin
	select  PhanLoai ,Sum(TongTien) as TongThu
	from THUCDON as td join GOIMON as gm on td.MaMon = gm.MaMon where TgGoiMon >=CONCAT('2022', '-', @thang,'-', '01') and TgGoiMon<=CONCAT('2022', '-', @thang,'-', '30') group by PhanLoai
end
else
begin
	select  PhanLoai ,Sum(TongTien) as TongThu
	from THUCDON as td join GOIMON as gm on td.MaMon = gm.MaMon where TgGoiMon >=CONCAT('2022', '-', @thang,'-', '01') and TgGoiMon<=CONCAT('2022', '-', @thang,'-', '31') group by PhanLoai
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[ThongKeLuongThang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[ThongKeLuongThang]
as
begin tran
	select  MONTH(NgayLamViec) as Thang , SUM(GioLamViec*LuongTheoGio) as LuongThang  from QUANLYCONGVIEC as qlcv join NHANVIEN as nv on qlcv.MaNV = nv.MaNV Join BANGLUONG as bl on nv.MaLuong = bl.MaLuong group by Month(NgayLamViec)

commit tran
GO
/****** Object:  Trigger [dbo].[tg_GoiMonCapNhat_ConLai_DaBan_THUCDON]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_GoiMonCapNhat_ConLai_DaBan_THUCDON] on [dbo].[GOIMON]
AFTER INSERT
AS
	DECLARE @STT int,
			@MaMon char(10), 
			@SoLuong int,
			@MaMonTrongThucDon char(10)
BEGIN
	/* Lay Ma Mon vua Them vao */
	SELECT  @STT = ne.STT,
			@MaMon = ne.MaMon, 
			@SoLuong = ne.SoLuong
	FROM inserted ne
	SELECT @MaMonTrongThucDon = td.MaMon
	FROM THUCDON td 
	WHERE td.MaMon = @MaMon


	BEGIN TRAN
	
	IF (@MaMonTrongThucDon IS NULL)
	BEGIN
		RAISERROR('Khong co mon an do trong thuc don', 16, 1)
		ROLLBACK
		RETURN
	END
	ELSE
	BEGIN
		/* Cap nhat so luong trong THUCDON */
		UPDATE THUCDON
		SET ConLai = ConLai - @SoLuong, DaBan = DaBan + @SoLuong
		WHERE MaMon = @MaMon
		
	END
	COMMIT TRAN
END
GO
ALTER TABLE [dbo].[GOIMON] ENABLE TRIGGER [tg_GoiMonCapNhat_ConLai_DaBan_THUCDON]
GO
/****** Object:  Trigger [dbo].[tg_SuaSoLuongMonCapNhat_ConLai_DaBan_THUCDON]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_SuaSoLuongMonCapNhat_ConLai_DaBan_THUCDON] on [dbo].[GOIMON]
AFTER UPDATE
AS
	DECLARE @STT int,
			@MaMon char(10), 
			@SoLuongNew int,
			@SoLuongOld int,
			@TrangThaiNew char(15),
			@TrangThaiOld char(15),
			@SLConLai int
BEGIN
	/* Lay Ma Mon vua Them vao */
	SELECT  @STT = ne.STT,
			@MaMon = ne.MaMon, 
			@SoLuongNew = ne.SoLuong,
			@TrangThaiNew = ne.TrangThai
	FROM inserted ne

	SELECT @SoLuongOld = ol.SoLuong, @TrangThaiOld = ol.TrangThai
	FROM deleted ol

	SELECT @SLConLai = td.ConLai
	FROM THUCDON td
	WHERE td.MaMon = @MaMon

	BEGIN TRAN

	IF (@TrangThaiNew = @TrangThaiOld)
	BEGIN
		IF (charindex('Thu tien', @TrangThaiOld) != 0)
		BEGIN
			IF (@SoLuongNew < @SLConLai)
			BEGIN
				/* Cap nhat so luong trong THUCDON */
				UPDATE THUCDON
				SET ConLai = ConLai + @SoLuongOld - @SoLuongNew, DaBan = DaBan + @SoLuongNew - @SoLuongOld 
				WHERE MaMon = @MaMon
			
			END
			ELSE
			BEGIN
				RAISERROR('Khong con du mon trong thuc don', 16, 1)
				ROLLBACK
				RETURN
			END	
		END
		ELSE
		BEGIN
			RAISERROR('Bep dang lam mon an cho ban', 16, 1)
			ROLLBACK
			RETURN
		END
	END
	ElSE
	BEGIN
	IF (charindex('Dang giao', @TrangThaiOld) != 0)
		BEGIN
			UPDATE GOIMON
			SET TgGiao = GETDATE()
			WHERE STT = @STT
		END
	END
	COMMIT TRAN
END
GO
ALTER TABLE [dbo].[GOIMON] ENABLE TRIGGER [tg_SuaSoLuongMonCapNhat_ConLai_DaBan_THUCDON]
GO
/****** Object:  Trigger [dbo].[tg_XoaGoiMonCapNhat_ConLai_THUCDON]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_XoaGoiMonCapNhat_ConLai_THUCDON] on [dbo].[GOIMON]
FOR DELETE
AS
	DECLARE @STT int,
			@MaMon char(10), 
			@SoLuong int,
			@TrangThaiOld char(15),
			@TrangThaiNew char(15)
BEGIN
	/* Lay Ma Mon vua Them vao */
	SELECT  @STT = ol.STT,
			@MaMon = ol.MaMon, 
			@SoLuong = ol.SoLuong,
			@TrangThaiOld = ol.TrangThai
	FROM deleted ol
	SELECT 	@TrangThaiNew = ne.TrangThai
	FROM inserted ne
	
	BEGIN TRAN
	IF (@TrangThaiOld = @TrangThaiNew)
	BEGIN
		IF (charindex('Thu tien', @TrangThaiOld) != 0)
		BEGIN
			/* Cap nhat so luong trong THUCDON */
			UPDATE THUCDON
			SET ConLai = ConLai + @SoLuong, DaBan = DaBan - @SoLuong
			WHERE MaMon = @MaMon
		
		END
		ELSE 
		BEGIN
			RAISERROR('Bep dang lam mon an cho ban', 16, 1)
			ROLLBACK
			RETURN
		END
	END
	
	COMMIT TRAN
END
GO
ALTER TABLE [dbo].[GOIMON] ENABLE TRIGGER [tg_XoaGoiMonCapNhat_ConLai_THUCDON]
GO
/****** Object:  Trigger [dbo].[tg_KhachHangSuDungMayTinh_CapNhat_QuanTri]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_KhachHangSuDungMayTinh_CapNhat_QuanTri] on [dbo].[KHACHHANG]
AFTER UPDATE
AS
	DECLARE  @MaMayNew varchar(10),
			@MaMayCu varchar(10),
			@MaKH varchar(10),
			@TgConLai bigint,
			@MaTK varchar(10)
BEGIN
	SELECT @MaMayNew=ne.MaMay, @MaMayCu=ne.MaMayCu, 
				@MaKH=ne.MaKH, @TgConLai = ne.ThoiGianConLai, @MaTK = ne.MaTK
	FROM inserted ne

	BEGIN TRAN

	IF (@MaMayNew IS NOT NULL)
	BEGIN

		/*Kiem tra loai may*/
		DECLARE @MayThuong varchar(10),
				@MayVip varchar(10)

		/*Lay loai may tu MaMay vua dang nhap*/
		SET @MayThuong = SUBSTRING(@MaMayNew, 1, 6)
		SET @MayVip = SUBSTRING(@MaMayNew, 1, 3)
	
	

		/*Neu la may thuong*/
		IF (@MayThuong = 'Thuong')
		BEGIN
			SET @MayThuong = SUBSTRING(@MaMayCu, 1, 6)
			SET @MayVip = SUBSTRING(@MaMayCu, 1, 3)

			IF (@MayVip='Vip')
				SET @TgConLai = 1.25  * @TgConLai
		END
		ELSE
		BEGIN
			/*Neu la may Vip*/
			IF (@MayVip = 'Vip')
			BEGIN
			SET @MayThuong = SUBSTRING(@MaMayCu, 1, 6)
			SET @MayVip = SUBSTRING(@MaMayCu, 1, 3)

			IF (@MayThuong='Thuong')
				SET @TgConLai = 0.8  * @TgConLai
			END
		END
		/*Update ThoiGianConLai*/
		UPDATE KHACHHANG
		SET ThoiGianConLai = @TgConLai
		WHERE MaKH = @MaKH

		/*Them vao bang QUANTRI*/
		DECLARE @MaTKNhanVienThuNgan varchar(10)

		SELECT @MaTKNhanVienThuNgan = nv.MaTK
		FROM [dbo].[NHANVIEN] nv 
		JOIN TAIKHOAN tk
		ON nv.MaTK = tk.MaTK
		JOIN [dbo].[CONGVIEC] cv
		ON cv.MaCV = nv.MaCV
		WHERE tk.TinhTrang = 'on' AND cv.TenCV = 'Thu Ngân'

		IF (@MaTKNhanVienThuNgan IS NULL)
		BEGIN
			RAISERROR('MaTKNhanVienThuNgan may null', 16, 1)
			ROLLBACK
			RETURN
		END
		ELSE
		BEGIN
			INSERT INTO [dbo].[QUANTRI] (MaTKAdmin, MaTKKhachHang, TgBatDau) 
			VALUES (@MaTKNhanVienThuNgan, @MaTK, GETDATE())
			
		END
	END
	COMMIT TRAN
END
GO
ALTER TABLE [dbo].[KHACHHANG] ENABLE TRIGGER [tg_KhachHangSuDungMayTinh_CapNhat_QuanTri]
GO
/****** Object:  Trigger [dbo].[TTMayTinhThayDoiKhachHang]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TTMayTinhThayDoiKhachHang] on [dbo].[MAYTINH]
AFTER UPDATE
AS
	DECLARE @NewTrangThai nvarchar(5),
			@MaMay char(10)
BEGIN
	SELECT @NewTrangThai = ne.TrangThai, @MaMay = ne.MaMay
	FROM inserted ne
	
	BEGIN TRAN

	IF (@NewTrangThai = 'off')
	BEGIN
		UPDATE KHACHHANG
		SET MaMay = null
		FROM KHACHHANG kh
		WHERE kh.MaMay = @MaMay
		
	END
	ELSE
	BEGIN
		RAISERROR('May tinh con hoat dong', 16, 1)
		ROLLBACK
		RETURN
	END
	COMMIT TRAN
END





GO
ALTER TABLE [dbo].[MAYTINH] ENABLE TRIGGER [TTMayTinhThayDoiKhachHang]
GO
/****** Object:  Trigger [dbo].[tg_DangXuatTaiKhoanUpdate_KHACHHANG_QUANTRI_KHACHHANGTHUONGXUYEN]    Script Date: 6/10/2023 2:03:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tg_DangXuatTaiKhoanUpdate_KHACHHANG_QUANTRI_KHACHHANGTHUONGXUYEN] on [dbo].[TAIKHOAN]
AFTER UPDATE
AS
BEGIN
	/*Lấy MaTK và TinhTrang mới đăng xuất*/
	DECLARE @MaTK char(10), @TinhTrangNew varchar(30)
	SELECT @MaTK = ne.MaTK, @TinhTrangNew = ne.TinhTrang
	FROM inserted ne

	
	BEGIN TRAN
	IF (charindex('tk', @MaTK)!=0)
	BEGIN
		IF (@TinhTrangNew='off')
		BEGIN
			/*Cập nhật TgKetThuc bản quản trị*/
			DECLARE @MaAdmin char(10), 	@TgBatDau datetime, @TgKetThuc datetime

			SELECT TOP(1) @MaAdmin = qt.MaTKAdmin, @TgBatDau = qt.TgBatdau 
			FROM QUANTRI qt
			WHERE qt.MaTKKhachHang = @MaTK
			ORDER BY qt.TgBatDau DESC

			UPDATE QUANTRI
			SET @TgKetThuc = GETDATE(), TgKetThuc = GETDATE()
			WHERE MaTKAdmin=@MaAdmin AND MaTKKhachHang=@MaTK AND TgBatDau=@TgBatDau

			/*Cập nhật TongThoiGian*/
			-- Lấy mã khách hàng
			DECLARE @MaKH char(10), 
					@TGConLai bigint
			SELECT @MaKH = kh.MaKH, @TGConLai = kh.ThoiGianConLai
			FROM KHACHHANG kh
			WHERE kh.MaTK = @MaTK
		
			--Tính thời gian cộng thêm
			DECLARE @TgThem float
			SELECT @TgThem = DATEDIFF(second, @TgBatDau, @TgKetThuc)
		

			IF (@TgThem <= @TGConLai)
			BEGIN
				/*Cập nhật mã máy cũ và số giờ còn lại, set null MaMay*/
				UPDATE KHACHHANG
				SET ThoiGianConLai = ThoiGianConLai - @TgThem, MaMayCu = MaMay, MaMay = null
				WHERE MaTK=@MaTK	
			END
			ELSE
			BEGIN
				RAISERROR('Thoi gian choi > Thoi gian con lai', 16, 1)
				ROLLBACK
				RETURN
			END
		END
	END
	COMMIT TRAN
END
GO
ALTER TABLE [dbo].[TAIKHOAN] ENABLE TRIGGER [tg_DangXuatTaiKhoanUpdate_KHACHHANG_QUANTRI_KHACHHANGTHUONGXUYEN]
GO
USE [master]
GO
ALTER DATABASE [NET_NEW] SET  READ_WRITE 
GO
