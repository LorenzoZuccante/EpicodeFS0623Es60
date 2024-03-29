USE [Ecommerce]
GO
/****** Object:  Table [dbo].[Prodotto]    Script Date: 16/02/2024 16:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodotto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeProdotto] [varchar](50) NOT NULL,
	[DescrizioneProdotto] [varchar](300) NULL,
	[ImgUrl] [varchar](255) NOT NULL,
	[Prezzo] [money] NOT NULL,
	[Marca] [varchar](50) NULL,
 CONSTRAINT [PK_Prodotto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
