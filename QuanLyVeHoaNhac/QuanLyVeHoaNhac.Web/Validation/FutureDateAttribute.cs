using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVeHoaNhac.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                // Kiểm tra nếu ngày nhập vào lớn hơn ngày giờ hiện tại
                if (dateTime > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                // Nếu nhỏ hơn hoặc bằng hiện tại thì báo lỗi
                return new ValidationResult(ErrorMessage ?? "Thời gian phải lớn hơn thời điểm hiện tại.");
            }

            // Trả về Success nếu giá trị null để nhường cho thẻ [Required] xử lý
            return ValidationResult.Success;
        }
    }
}