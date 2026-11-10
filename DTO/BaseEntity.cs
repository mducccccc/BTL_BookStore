using System;

namespace BTL.DTO
{
    /// <summary>
    /// Lớp thực thể cơ sở (BaseEntity) cung cấp các thuộc tính chung cho các đối tượng trong hệ thống.
    /// Đáp ứng tiêu chí OOP: Kế thừa (Inheritance).
    /// </summary>
    public abstract class BaseEntity
    {
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string NguoiTao { get; set; } = "Hệ thống";
        public bool IsActive { get; set; } = true;

        public virtual string GetSummaryInfo()
        {
            return $"Tạo lúc: {NgayTao:dd/MM/yyyy HH:mm} bởi {NguoiTao}";
        }
    }
}
