namespace InternshipManagementSystem.Domain.Entities
{
    public enum InternshipStatus
    {
        Deleted = -1, // Silindi
        Pending = 0, // Beklemede
        ApplicationRejected = 1, // Staj başvurusu reddedildi
        ModificationRequiredInStartInformation = 2, // Staj başlatma bilgilerinde düzenleme gerekli
        FilesAwaited = 3, // Staj dosyaları bekleniyor
        FilesUnderReview = 4, // Staj dosyaları incelemede
        FilesApproved = 5, // Staj dosyaları onaylandı
        DocumentsAwaitingSubmission = 6, // Staj evrakları teslim bekleniyor
        DocumentsSubmitted = 7, // Staj evrakları teslim edildi
        DocumentsNotSubmitted = 8, // Staj evrakları teslim edilmedi
        DocumentsUnderReview = 9, // Staj evrakları kontrol ediliyor
        InternshipCompleted = 10, // Staj tamamlandı
        InternshipCanceled = 11 // Staj iptal edildi
    }

}