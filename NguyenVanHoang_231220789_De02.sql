CREATE DATABASE NguyenVanHoang_231220789_De02;
GO

USE NguyenVanHoang_231220789_De02;
GO

CREATE TABLE NvhCatalog (
    nvhId INT PRIMARY KEY, 
    nvhCateName NVARCHAR(100) NOT NULL,
    nvhCatePrice INT NOT NULL,
    nvhCateQty INT NOT NULL,
    nvhPicture NVARCHAR(255),
    nvhCateActive BIT NOT NULL
);
GO

INSERT INTO NvhCatalog (nvhCateName, nvhCatePrice, nvhCateQty, nvhPicture, nvhCateActive)
VALUES
(N'Laptop Dell Inspiron', 15000000, 10, N'dell.jpg', 1),
(N'Điện thoại Samsung Galaxy', 7000000, 20, N'samsung.jpg', 1),
(N'Nguyen Van Hoang - 231220789', 0, 1, N'hoang.jpg', 1);
GO


