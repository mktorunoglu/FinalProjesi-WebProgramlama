CREATE TABLE [TBL_FIRMA] (
  [FIRMA_ID] int not null identity(1,1),
  [KULLANICI_ADI] varchar(10),
  [FIRMA_ADI] varchar(20),
  [YONETICI_ID]  int, --FK TAMAMLANDI
  [TELEFON] varchar(10),
  [ADRES] varchar(100),
  [MAIL] varchar(30),
  PRIMARY KEY ([FIRMA_ID]),
);

CREATE TABLE [TBL_YONETICI] (
  [YONETICI_ID] int not null identity(1,1),
  [FIRMA_ID] int, --FK TAMAMLANDI
  [YONETICI_AD] varchar(10),
  [YONETICI_SOYAD] varchar(10),
  [KULLANICI_ADI] varchar(10),
  [SIFRE] varchar(10),
  PRIMARY KEY ([YONETICI_ID]),
  FOREIGN KEY (FIRMA_ID) REFERENCES TBL_FIRMA(FIRMA_ID)

);

ALTER TABLE TBL_FIRMA
ADD FOREIGN KEY (YONETICI_ID) REFERENCES TBL_YONETICI(YONETICI_ID);

CREATE TABLE [TBL_HAMMADDE] (
  [HAMMADDE_ID] int not null identity(1,1),
  [HAMMADDE_ADI] varchar(20),
  [STOK_ADEDI] int,
  [STOK_ESIK_DEGERI] int check (STOK_ESIK_DEGERI > 0),
  [TEMIN_SURESI] int,
  PRIMARY KEY ([HAMMADDE_ID])
);

CREATE TABLE [TBL_URUN] (
  [URUN_ID] int not null identity(1,1),
  [URUN_ADI] varchar(50),
  [URUN_MODEL] varchar(50),
  [URUN_EBAT] varchar(50),
  [P_BAKIM_SURESI] varchar(50),
  [ALIS_FIYAT] int,
  [SATIS_FIYAT] int,
  [KAR] as [SATIS_FIYAT]- [ALIS_FIYAT],
  TEMIN_SURESI int,
  [STOK_ADEDI] int,
  [STOK_ESIK_DEGERI] int,
  RESIM varchar(250),
  PRIMARY KEY ([URUN_ID])
);


CREATE TABLE[TBL_K_HAMMADELER](
  [K_HAMMADELER_ID] int not null identity(1,1),
  [HAMMADDE_ID] int, --FK tamamlandý
  [HAMMADDE_ADI] varchar(20),
  [URUN_ID] int, --FK tamamlandý
  PRIMARY KEY ([K_HAMMADELER_ID]),
  FOREIGN KEY (URUN_ID) REFERENCES TBL_URUN(URUN_ID),
  FOREIGN KEY (HAMMADDE_ID) REFERENCES TBL_HAMMADDE(HAMMADDE_ID)

);


CREATE TABLE [TBL_BAYI] (
  [BAYI_ID] int not null identity(1,1),
  [BAYI_ADI] varchar(10),
  [KULLANICI_ADI] varchar(10),
  [SIFRE] varchar(10),
  [TELEFON] varchar(10),
  [ADRES] varchar(100),
  [FIRMA_ID] int,  --FK TAMAMLANDI
  MAIL varchar(50),
  PRIMARY KEY ([BAYI_ID]),
  FOREIGN KEY (FIRMA_ID) REFERENCES TBL_FIRMA(FIRMA_ID)

);

CREATE TABLE [TBL_SIPARIS] (
  [SIPARIS_ID] int not null identity(1,1),
  [URUN_ID] int, --FK tamamlandý
  [BAYI_ID] int, --FK tamamlandý
  URUN_ADET int,
  [TARIH] VARCHAR(50),
  [ALIS_FIYAT] int, --URUN IDSINE BAGLI
  [TUTAR] AS URUN_ADET * ALIS_FIYAT , -- URUN ADET * ALIS_FIYAT
  [TEMIN_SURESI] int, -- URUN IDSÝNE BAÐLI URUNLER TABLOSUNDAN GELEN TEMIN SURESI
  [FIRMA_ID] int, --FK tamamlandý
  PRIMARY KEY ([SIPARIS_ID]),
  FOREIGN KEY (BAYI_ID) REFERENCES TBL_BAYI(BAYI_ID) ,
  FOREIGN KEY (FIRMA_ID) REFERENCES TBL_FIRMA(FIRMA_ID),
  FOREIGN KEY (URUN_ID) REFERENCES TBL_URUN(URUN_ID)

);

CREATE TABLE [TBL_ODEME] (
  [ODEME_ID] int not null identity(1,1),
  [ODEME_YONTEMI] varchar(10),
  [BAYI_ID] int, --FK tamamlandý
  [FIRMA_ID] int, --FK tamamlandý
  [SIPARIS_ID] int
  PRIMARY KEY ([ODEME_ID]), 
  FOREIGN KEY (SIPARIS_ID) REFERENCES TBL_SIPARIS(SIPARIS_ID),
  FOREIGN KEY (BAYI_ID) REFERENCES TBL_BAYI(BAYI_ID),
  FOREIGN KEY (FIRMA_ID) REFERENCES TBL_FIRMA(FIRMA_ID)

  );


CREATE TABLE [TBL_MUSTERI] (
  [MUSTERI_ID] int not null identity(1,1),
  [AD] varchar(10),
  [SOYAD] varchar(10),
  [TELEFON] varchar(10),
  [ADRES] varchar(50),
  [MAIL] varchar(20), 
  [BAYI_ID] int, --FK tamamlandý
  [KULLANICI_ADI] varchar(50),
  [SIFRE] varchar(50),
  [DOGUM_TARIHI] varchar(50),
  PRIMARY KEY ([MUSTERI_ID]),
  FOREIGN KEY (BAYI_ID) REFERENCES TBL_BAYI(BAYI_ID)
);


CREATE TABLE[TBL_M_URUNLER](
	[M_URUNLER_ID] int not null identity(1,1),
	[MUSTERI_ID] int, --FK tamamlandý
	[URUN_ID] int, --FK tamamlandý
	[P_BAKIM_SURESI] varchar(10), --urun idsine baglý bakým süresi
	FOREIGN KEY (MUSTERI_ID) REFERENCES TBL_MUSTERI(MUSTERI_ID),
	FOREIGN KEY (URUN_ID) REFERENCES TBL_URUN(URUN_ID)
);

CREATE TABLE [TBL_BAKIM] (
  [BAKIM_ID] int not null identity(1,1),
  [MUSTERI_ID] int, --FK tamamlandý
  [URUN_ID] int, --FK tamamlandý
  [BAKIM_ISLEMI] varchar(100),
  [BAKIM_TARIHI] date default '2019-01-01',
  [BAYI_ID] int, --FK tamamlandý
  [MALIYET] int,
  PRIMARY KEY ([BAKIM_ID]),
  FOREIGN KEY (MUSTERI_ID) REFERENCES TBL_MUSTERI(MUSTERI_ID),
  FOREIGN KEY (URUN_ID) REFERENCES TBL_URUN(URUN_ID),
  FOREIGN KEY (BAYI_ID) REFERENCES TBL_BAYI(BAYI_ID)
);


CREATE TABLE [TBL_SATIS] (
  [SATIS_ID] int not null identity(1,1),	
  [BAYI_ID] int, --FK tmm
  [MUSTERI_ID] int, --FK tmm
  [URUN_ID] int, --FK tmm
  [SATIS_FIYAT] int, -- URUN IDSINE BAGLI SATIS FÝYATI
  [ADET] int, 
  [BIRIM_KAR] int, -- URUN IDSINE BAÐLI [KAR] BÝLGÝSÝ 
  [TOPLAM_KAR] AS ADET * BIRIM_KAR, -- ADET * BIRIM_KAR
  [MALIYET] AS SATIS_FIYAT * ADET, -- SATIS_FIYAT * ADET
  FOREIGN KEY (MUSTERI_ID) REFERENCES TBL_MUSTERI(MUSTERI_ID),
  FOREIGN KEY (URUN_ID) REFERENCES TBL_URUN(URUN_ID),
  FOREIGN KEY (BAYI_ID) REFERENCES TBL_BAYI(BAYI_ID)
);

