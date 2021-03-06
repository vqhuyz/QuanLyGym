USE [master]
GO
/****** Object:  Database [GYM]    Script Date: 5/20/2020 11:28:11 PM ******/
CREATE DATABASE [GYM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GYM', FILENAME = N'C:\GYM.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GYM_log', FILENAME = N'C:\GYM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GYM] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GYM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GYM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GYM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GYM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GYM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GYM] SET ARITHABORT OFF 
GO
ALTER DATABASE [GYM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GYM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GYM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GYM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GYM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GYM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GYM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GYM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GYM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GYM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GYM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GYM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GYM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GYM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GYM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GYM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GYM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GYM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GYM] SET  MULTI_USER 
GO
ALTER DATABASE [GYM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GYM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GYM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GYM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GYM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GYM]
GO
/****** Object:  Table [dbo].[tblGoiTap]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGoiTap](
	[MaGT] [nvarchar](20) NOT NULL,
	[TenGT] [nvarchar](50) NULL,
	[ThoiHan] [int] NULL,
	[Gia] [int] NULL,
 CONSTRAINT [PK_tblGoiTap] PRIMARY KEY CLUSTERED 
(
	[MaGT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [nvarchar](20) NULL,
	[TenKH] [nvarchar](50) NULL,
	[SDT] [char](10) NULL,
	[MaGT] [nvarchar](20) NULL,
	[ThanhToan] [int] NULL,
	[NgayTap] [date] NULL,
 CONSTRAINT [PK_tblKhachHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[MaNV] [nvarchar](20) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](20) NULL,
	[SoCMND] [char](12) NULL,
	[SoDT] [char](10) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[LuongCoBan] [int] NULL,
	[HinhAnh] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSanPham]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSanPham](
	[MaSP] [nvarchar](20) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[Loai] [nvarchar](50) NULL,
	[NgayNhap] [date] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[TrongLuong] [nvarchar](20) NULL,
	[HinhAnh] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblSanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTaiKhoan]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaiKhoan](
	[MaNV] [nvarchar](20) NOT NULL,
	[TaiKhoan] [nvarchar](20) NULL,
	[MatKhau] [nvarchar](20) NULL,
	[LoaiTaiKhoan] [nvarchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblThanhVien]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblThanhVien](
	[MaTV] [nvarchar](20) NOT NULL,
	[TenTV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](20) NULL,
	[MaGT] [nvarchar](20) NULL,
	[HocPhi] [int] NULL,
	[SDT] [char](10) NULL,
	[NgayDangKi] [date] NULL,
	[NgayHetHan] [date] NULL,
	[MaNV] [nvarchar](20) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblThanhVien] PRIMARY KEY CLUSTERED 
(
	[MaTV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblThietBi]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblThietBi](
	[MaTB] [nvarchar](20) NOT NULL,
	[TenTB] [nvarchar](50) NULL,
	[Loai] [nvarchar](20) NULL,
	[SoLuong] [int] NULL,
	[HangSX] [nvarchar](50) NULL,
	[SoLuongHu] [int] NULL,
	[TinhTrang] [nvarchar](20) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[HinhAnh] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblThietBi] PRIMARY KEY CLUSTERED 
(
	[MaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'GT01', N'Gói tập 3 tháng', 90, 900000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'GT02', N'Gói tập 2 tháng', 60, 600000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'GT03', N'Gói tập 1 tháng', 30, 300000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'GT04', N'Gói tập 20 ngày', 20, 200000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'GT05', N'Gói tập 15 ngày', 15, 150000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'GT06', N'Gói tập 10 ngày ', 10, 100000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'KH01', N'Gói tập 1 ngày', 1, 100000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'KH02', N'Gói tập 6 giờ', 6, 70000)
INSERT [dbo].[tblGoiTap] ([MaGT], [TenGT], [ThoiHan], [Gia]) VALUES (N'KH03', N'Gói tập 2 giờ', 2, 50000)
SET IDENTITY_INSERT [dbo].[tblKhachHang] ON 

INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (1, N'NV02', N'Dương Thăng Nhật', N'096612138 ', N'KH01', 100000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (2, N'NV03', N'Nguyễn Minh Tú', N'096612139 ', N'KH02', 70000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (3, N'NV04', N'Lê Thị Thu', N'096612140 ', N'KH01', 100000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (4, N'NV05', N'Hồ Nhật Tùng', N'096612141 ', N'KH02', 70000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (5, N'NV02', N'Nguyễn Thị Vân', N'096612142 ', N'KH03', 50000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (6, N'NV03', N'Nguyễn Sỹ Hiệp', N'096612143 ', N'KH02', 70000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (7, N'NV04', N'Võ Văn Lương', N'096612144 ', N'KH01', 100000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (8, N'NV05', N'Đinh Thị Thu Thảo', N'096612145 ', N'KH02', 70000, CAST(N'2019-12-17' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (9, N'NV02', N'Nguyễn Ngọc Thảo', N'096612146 ', N'KH01', 100000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (10, N'NV03', N'Cao Nữ Tú Châu', N'096612147 ', N'KH02', 70000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (11, N'NV04', N'Phạm Phương Duy', N'096612148 ', N'KH01', 100000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (12, N'NV05', N'Phạm Nguyễn Công Đức', N'096612149 ', N'KH02', 70000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (13, N'NV02', N'Lê Nguyễn Thế Vỹ', N'096612150 ', N'KH01', 100000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (14, N'NV03', N'Nguyễn Chí Phúc', N'096612151 ', N'KH02', 70000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (15, N'NV04', N'Trần Văn Tuấn', N'096612152 ', N'KH01', 100000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (16, N'NV05', N'Nguyễn Quốc Thịnh', N'096612153 ', N'KH02', 70000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (17, N'NV05', N'Cao Nguyễn Phượng Quyên', N'096612154 ', N'KH03', 50000, CAST(N'2019-12-18' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (18, N'NV02', N'Huỳnh Văn Nghĩa ', N'096612155 ', N'KH03', 50000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (19, N'NV03', N'Triệu Tấn Tuấn', N'096612156 ', N'KH03', 50000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (20, N'NV04', N'Văn Sĩ Hiệp', N'096612157 ', N'KH03', 50000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (21, N'NV05', N'Phạm Nhật Trường', N'096612158 ', N'KH03', 50000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (22, N'NV02', N'Trần Thành Long', N'096612159 ', N'KH01', 100000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (23, N'NV03', N'Nguyễn Minh Duy', N'096612160 ', N'KH02', 70000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (24, N'NV04', N'Trần Duy Anh Hòa', N'096612161 ', N'KH01', 100000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (25, N'NV05', N'Lý Gia Đạt', N'096612162 ', N'KH02', 70000, CAST(N'2019-12-19' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (26, N'NV02', N'Phạm Xuân Vỹ', N'096612163 ', N'KH03', 50000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (27, N'NV03', N'Lê Tấn Phong', N'096612164 ', N'KH03', 50000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (28, N'NV04', N'Trần Công Thành', N'096612165 ', N'KH03', 50000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (29, N'NV05', N'Trần Thành Tín', N'096612166 ', N'KH01', 100000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (30, N'NV05', N'Bùi Thị Phượng', N'096612167 ', N'KH02', 70000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (31, N'NV02', N'Nguyễn Nhật Sinh', N'096612168 ', N'KH01', 100000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (32, N'NV03', N'Tạ Xuân Thạch', N'096612169 ', N'KH02', 70000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (33, N'NV04', N'Lê Công Lương', N'096612170 ', N'KH01', 100000, CAST(N'2019-12-20' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (34, N'NV01', N'Vũ Quốc Huy', N'0828365961', N'KH03', 50000, CAST(N'2019-12-21' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (35, N'NV01', N'Trần Công Thức', N'0989169012', N'KH02', 70000, CAST(N'2019-12-21' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (36, N'NV02', N'Huỳnh Kim Minh Hiền', N'0828365962', N'KH01', 100000, CAST(N'2019-12-21' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (38, N'NV05', N'Vũ Quốc Huân', N'0360991233', N'KH03', 50000, CAST(N'2019-12-22' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (39, N'NV05', N'Mai Siêu Phong', N'0360991443', N'KH02', 70000, CAST(N'2019-12-22' AS Date))
INSERT [dbo].[tblKhachHang] ([id], [MaNV], [TenKH], [SDT], [MaGT], [ThanhToan], [NgayTap]) VALUES (40, N'ADMIN', N'Vu  Quoc Huy', N'0828365963', N'KH01', 100000, CAST(N'2019-12-25' AS Date))
SET IDENTITY_INSERT [dbo].[tblKhachHang] OFF
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'ADMIN', N'Vũ Quốc Huy', N'Nam', N'036099008132', N'0828365961', N'Dĩ An', N'ADMIN', 1999, N'\img\ADMIN')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'NV01', N'Nguyễn Hoàng Long', N'Nam', N'221482397   ', N'0923124975', N'Thủ Đức', N'Quản lý', 6000000, N'\img\NV01')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'NV02', N'Nguyễn Ngọc Yến Linh', N'Nữ', N'1654862358  ', N'0356841285', N'Quận 2', N'Thu ngân', 4500000, N'\img\NV02')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'NV03', N'Tạ Mỹ Linh', N'Nữ', N'1425136854  ', N'0923564812', N'Quận 9', N'Thu ngân', 4500000, N'\img\NV03')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'NV04', N'Trần Thị Mỹ Chi', N'Nữ', N'4512368541  ', N'0354685214', N'Bình Chánh', N'Nhân viên', 3500000, N'\img\NV04')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'NV05', N'Trần Ngọc Khánh', N'Nam', N'1425361524  ', N'0354126852', N'Bình Thạnh', N'Nhân viên', 3500000, N'\img\NV05')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'NV06', N'Vũ Huy', N'Nam', N'036099008132', N'0828365961', N'Dĩ An', N'QuanLy', 1999, N'\img\NV06')
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [SoCMND], [SoDT], [DiaChi], [ChucVu], [LuongCoBan], [HinhAnh]) VALUES (N'USER', N'Huynh Kim Minh Hien', N'Nam', N'221482397   ', N'0923124975', N'Thủ Đức', N'USER', 1999, N'\img\USER')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP01', N'Titanium Whey Isolate Supreme', N'Isolate Protein', CAST(N'2019-12-20' AS Date), 50, 1850000, N'27g', N'\img\SP01')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP02', N'Labrada 100% Micellar Casein', N'Micellar Casein Protein', CAST(N'2019-12-20' AS Date), 50, 1650000, N'24g', N'\img\SP02')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP03', N'Carnivor Beef Protein Isolate', N'Protein', CAST(N'2019-12-20' AS Date), 50, 1264080, N'24g', N'\img\SP03')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP04', N'Cor Performance Whey Protein', N'Whey protein isolate', CAST(N'2019-12-20' AS Date), 50, 1280180, N'25g', N'\img\SP04')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP05', N'Cor Performance Whey 1 Liều Dùng', N'Whey protein isolate', CAST(N'2019-12-20' AS Date), 50, 128018, N'25', N'\img\SP05')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP06', N'Cor Performance Whey Protein Isolate 909g', N'Whey protein isolate', CAST(N'2019-12-20' AS Date), 50, 1152162, N'25', N'\img\SP06')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP07', N'RSP IsoPost Whey Protein', N'Whey Protein isolate', CAST(N'2019-12-20' AS Date), 50, 790000, N'26g', N'\img\SP07')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP08', N'Total Isolate', N'whey isolate', CAST(N'2019-12-20' AS Date), 50, 360000, N'22g', N'\img\SP08')
INSERT [dbo].[tblSanPham] ([MaSP], [TenSP], [Loai], [NgayNhap], [SoLuong], [DonGia], [TrongLuong], [HinhAnh]) VALUES (N'SP09', N'Total Isolate Hộp Nhỏ 849g', N'whey isolate', CAST(N'2019-12-20' AS Date), 50, 220000, N'22g', N'\img\SP09')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV01', N'NV01', N'1', N'ADMIN')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV02', N'NV02', N'TN', N'USER')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV03', N'NV03', N'TN', N'USER')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV04', N'NV04', N'NV', N'USER')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV05', N'NV05', N'NV', N'USER')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'ADMIN', N'1', N'1', N'ADMIN')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'USER', N'2', N'1', N'USER')
INSERT [dbo].[tblTaiKhoan] ([MaNV], [TaiKhoan], [MatKhau], [LoaiTaiKhoan]) VALUES (N'NV06', N'5', N'1', N'ADMIN')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV01', N'Nguyễn Minh Hoàng', N'Nam', N'GT01', 900000, N'0828365961', CAST(N'2019-12-17' AS Date), CAST(N'2020-03-15' AS Date), N'NV02', N'dáng người không cân đối')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV02', N'Đinh Tiến Phong', N'Nam', N'GT02', 600000, N'096612170 ', CAST(N'2019-12-17' AS Date), CAST(N'2020-02-14' AS Date), N'NV03', N'dáng người không cân đối')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV03', N'Phạm Thị Thảo', N'Nữ', N'GT03', 300000, N'096612171 ', CAST(N'2019-12-17' AS Date), CAST(N'2020-01-15' AS Date), N'NV04', N'dáng người không cân đối')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV04', N'Đặng Thị Ngọc Như', N'Nữ', N'GT04', 200000, N'096612172 ', CAST(N'2019-12-17' AS Date), CAST(N'2020-01-05' AS Date), N'NV05', N'sức khỏe yếu')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV05', N'Châu Thùy Dương', N'Nữ', N'GT02', 600000, N'096612173 ', CAST(N'2019-12-17' AS Date), CAST(N'2020-02-14' AS Date), N'NV02', N'sức khỏe yếu')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV06', N'Nguyễn Thị Xuân Anh', N'Nữ', N'GT03', 300000, N'096612174 ', CAST(N'2019-12-17' AS Date), CAST(N'2020-01-15' AS Date), N'NV03', N'người quá gầy')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV07', N'Trần Thị Thúy Kiều', N'Nữ', N'GT01', 900000, N'096612175 ', CAST(N'2019-12-17' AS Date), CAST(N'2020-03-15' AS Date), N'NV04', N'người hơi mập')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV08', N'Nguyễn Như Dương', N'Nữ', N'GT03', 300000, N'096612176 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-01-16' AS Date), N'NV05', N'thể trạng kém')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV09', N'Phùng Vũ Khánh Duyên', N'Nữ', N'GT04', 200000, N'096612177 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-01-06' AS Date), N'NV02', N'dáng không chuẩn')
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV10', N'Lê Lưu Như Quỳnh', N'Nữ', N'GT02', 600000, N'096612178 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-02-15' AS Date), N'NV03', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV11', N'Hoàng Ngọc Thanh Trúc', N'Nữ', N'GT03', 300000, N'096612179 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-01-16' AS Date), N'NV04', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV12', N'Bùi Nguyễn Thanh Nhi ', N'Nữ', N'GT01', 900000, N'096612180 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-03-16' AS Date), N'NV05', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV13', N'Lê Thị Hồng Nhung', N'Nữ', N'GT03', 300000, N'096612181 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-01-16' AS Date), N'NV02', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV14', N'Đoàn Thị Hải Yến', N'Nữ', N'GT04', 200000, N'096612182 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-01-06' AS Date), N'NV03', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV15', N'Trần Anh Thư', N'Nữ', N'GT01', 900000, N'096612183 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-03-16' AS Date), N'NV04', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV16', N'Tạ Yến Nhi', N'Nữ', N'GT03', 300000, N'096612184 ', CAST(N'2019-12-18' AS Date), CAST(N'2020-01-16' AS Date), N'NV05', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV17', N'Nguyễn Thị Liên', N'Nữ', N'GT04', 200000, N'096612185 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-01-07' AS Date), N'NV02', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV18', N'Võ Văn Vỹ', N'Nữ', N'GT02', 600000, N'096612186 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-02-16' AS Date), N'NV03', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV19', N'Trần Tấn Phát ', N'Nam', N'GT03', 300000, N'096612187 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-01-17' AS Date), N'NV04', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV20', N'Hồ Tấn Vỹ', N'Nam', N'GT01', 900000, N'096612188 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-03-17' AS Date), N'NV05', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV21', N'Nguyễn Song Nguyệt Linh', N'Nữ', N'GT01', 900000, N'096612189 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-03-17' AS Date), N'NV02', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV22', N'Phan Văn Quốc Huy', N'Nam', N'GT03', 300000, N'096612190 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-01-17' AS Date), N'NV03', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV23', N'Võ Đức Lợi', N'Nam', N'GT04', 200000, N'096612191 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-01-07' AS Date), N'NV04', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV24', N'Nguyễn Thị Thanh Trúc', N'Nữ', N'GT02', 600000, N'096612192 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-02-16' AS Date), N'NV05', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV25', N'Trần Anh Thư', N'Nữ', N'GT03', 300000, N'096612193 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-01-17' AS Date), N'NV02', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV26', N'Tạ Yến Nhi', N'Nữ', N'GT01', 900000, N'096612194 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-03-17' AS Date), N'NV03', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV27', N'Nguyễn Thị Liên', N'Nữ', N'GT02', 600000, N'096612195 ', CAST(N'2019-12-19' AS Date), CAST(N'2020-02-16' AS Date), N'NV04', NULL)
INSERT [dbo].[tblThanhVien] ([MaTV], [TenTV], [GioiTinh], [MaGT], [HocPhi], [SDT], [NgayDangKi], [NgayHetHan], [MaNV], [GhiChu]) VALUES (N'TV28', N'vu huy', N'Nam', N'GT03', 300000, N'0828365961', CAST(N'2019-12-25' AS Date), CAST(N'2020-01-24' AS Date), N'ADMIN', N'the chat qua yeu')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB01', N'Tạ cầm tay', N'Cầm tay', 20, N'Brosman', 2, N'Tốt', N'', N'\img\TB01')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB02', N'Tạ nắm ấm', N'Cầm tay', 20, N'Brosman', 0, N'Tốt', N'', N'\img\TB02')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB03', N'Thanh tạ đòn', N'Cầm tay', 20, N'BoFit', 1, N'Tốt', N'', N'\img\TB03')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB04', N'Bánh xe tập bụng', N'Cầm tay', 20, N'Gobetters', 0, N'Tốt', N'', N'\img\TB04')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB05', N'Băng ghế tập', N'Ghế', 10, N'SportsLand', 0, N'Tốt', N'', N'\img\TB05')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB06', N'Ghế dụng cụ', N'Ghế', 10, N'SportRun', 0, N'Tốt', N'', N'\img\TB06')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB07', N'Ghế tập dưới thân', N'Ghế', 10, N'SportsLine', 0, N'Tốt', N'', N'\img\TB07')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB08', N'Máy đạp chân', N'Máy tập', 10, N'SportsLine', 0, N'Tốt', N'', N'\img\TB08')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB09', N'Máy tập bắp chân', N'Máy tập', 10, N'Elip', 1, N'Tốt', N'', N'\img\TB09')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB10', N'Máy chạy bộ', N'Máy tập', 10, N'BoFit', 0, N'Tốt', N'', N'\img\TB10')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB11', N'Máy tập ngực, tay sau', N'Máy tập', 10, N'SprotRun', 0, N'Tốt', N'', N'\img\TB11')
INSERT [dbo].[tblThietBi] ([MaTB], [TenTB], [Loai], [SoLuong], [HangSX], [SoLuongHu], [TinhTrang], [GhiChu], [HinhAnh]) VALUES (N'TB12', N'Máy kéo cáp ròng rọc', N'Máy tập', 10, N'Elip', 0, N'Tốt', N'', N'\img\TB12')
ALTER TABLE [dbo].[tblKhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tblKhachHang_tblGoiTap] FOREIGN KEY([MaGT])
REFERENCES [dbo].[tblGoiTap] ([MaGT])
GO
ALTER TABLE [dbo].[tblKhachHang] CHECK CONSTRAINT [FK_tblKhachHang_tblGoiTap]
GO
ALTER TABLE [dbo].[tblKhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tblKhachHang_tblNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblNhanVien] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblKhachHang] CHECK CONSTRAINT [FK_tblKhachHang_tblNhanVien]
GO
ALTER TABLE [dbo].[tblTaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_tblTaiKhoan_tblNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblNhanVien] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTaiKhoan] CHECK CONSTRAINT [FK_tblTaiKhoan_tblNhanVien]
GO
ALTER TABLE [dbo].[tblThanhVien]  WITH CHECK ADD  CONSTRAINT [FK_tblThanhVien_tblGoiTap] FOREIGN KEY([MaGT])
REFERENCES [dbo].[tblGoiTap] ([MaGT])
GO
ALTER TABLE [dbo].[tblThanhVien] CHECK CONSTRAINT [FK_tblThanhVien_tblGoiTap]
GO
ALTER TABLE [dbo].[tblThanhVien]  WITH CHECK ADD  CONSTRAINT [FK_tblThanhVien_tblNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblNhanVien] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblThanhVien] CHECK CONSTRAINT [FK_tblThanhVien_tblNhanVien]
GO
/****** Object:  StoredProcedure [dbo].[Report]    Script Date: 5/20/2020 11:28:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Report]
	@NgayTap DateTime
AS
	SELECT *
	FROM tblKhachHang
	WHERE NgayTap = @NgayTap
GO
USE [master]
GO
ALTER DATABASE [GYM] SET  READ_WRITE 
GO
