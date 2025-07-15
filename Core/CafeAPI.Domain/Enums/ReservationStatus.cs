namespace CafeAPI.Domain.Enums
{
    public class ReservationStatus
    {
        public const string Beklemede = "BEKLİYOR"; // Onay bekleyen rezervasyonlar
        public const string Onaylandi = "ONAYLANDI"; // Başarıyla onaylanmış
        public const string IptalEdildi = "IPTAL_EDILDI"; // Müşteri veya işletme tarafından iptal
        public const string Tamamlandi = "TAMAMLANDI"; // Hizmet gerçekleşti, süreç bitti
    }
}
