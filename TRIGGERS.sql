CREATE TRIGGER [dbo].[TEMIN_SURESI]
ON [dbo].[TBL_K_HAMMADELER]
AFTER INSERT
AS
BEGIN
-- kullanýlan hammaddelere eklenenhammaddenin idsini tut

DECLARE @HammaddeID int
select @HammaddeID = HAMMADDE_ID from inserted

DECLARE @HammaddeAdi varchar(20)
SELECT @HammaddeAdi=HAMMADDE_ADI FROM TBL_HAMMADDE WHERE HAMMADDE_ID = @HammaddeID

UPDATE TBL_K_HAMMADELER
SET HAMMADDE_ADI = @HammaddeAdi
WHERE HAMMADDE_ID = @HammaddeID


END

-- --------------------------------------------------------------------------------
-- 
-- --------------------------------------------------------------------------------

CREATE TRIGGER [dbo].[siparis]
on [dbo].[TBL_SIPARIS]
AFTER INSERT
AS
BEGIN
DECLARE @UrunId int
select @UrunId = URUN_ID from inserted

DECLARE @alisFiyat int
SELECT @alisFiyat = ALIS_FIYAT FROM TBL_URUN WHERE URUN_ID = @UrunId

DECLARE @adet int
select @adet = URUN_ADET from inserted

DECLARE @teminSuresi int
SELECT @teminSuresi = TEMIN_SURESI FROM TBL_URUN WHERE URUN_ID = @UrunId

UPDATE TBL_SIPARIS
SET ALIS_FIYAT = @alisFiyat
WHERE URUN_ID = @UrunId

UPDATE TBL_SIPARIS
SET TEMIN_SURESI = @teminSuresi
WHERE URUN_ID = @UrunId

UPDATE TBL_URUN
SET STOK_ADEDI = STOK_ADEDI - @adet
WHERE URUN_ID = @UrunId


END