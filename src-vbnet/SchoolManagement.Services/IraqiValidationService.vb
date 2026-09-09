Imports System
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Namespace Services
    ''' <summary>
    ''' خدمة التحقق وتنسيق المعايير العراقية (أرقام الهواتف، الهويات، العملة، والعناوين)
    ''' </summary>
    Public Class IraqiValidationService
        Public Shared ReadOnly IraqiProvinces As New List(Of String) From {
            "بغداد", "البصرة", "نينوى", "أربيل", "النجف الأشرف", "كربلاء المقدسة",
            "كركوك", "الأنبار", "ذي قار", "بابل", "السليمانية", "ديالى",
            "صلاح الدين", "ميسان", "واسط", "الديوانية", "دهوك", "المثنى"
        }

        ''' <summary>
        ''' التحقق من أرقام الهواتف العراقية واكتشاف شبكة الاتصال
        ''' شبكات الاتصال: زين العراق (078, 079)، آسيا سيل (077)، كورك تيليكوم (075)
        ''' </summary>
        Public Shared Function ValidatePhone(phone As String) As PhoneValidationResult
            Dim result As New PhoneValidationResult()

            If String.IsNullOrWhiteSpace(phone) Then
                result.IsValid = False
                result.ErrorMessage = "رقم الهاتف مطلوب."
                Return result
            End If

            ' تنظيف الرقم من المسافات والرموز
            Dim cleaned = Regex.Replace(phone.Trim(), "[^\d\+]", "")

            ' تحويل الصيغة الدولية إلى محلية للتحقق
            Dim localPhone = cleaned
            If localPhone.StartsWith("+964") Then
                localPhone = "0" & localPhone.Substring(4)
            ElseIf localPhone.StartsWith("00964") Then
                localPhone = "0" & localPhone.Substring(5)
            ElseIf localPhone.StartsWith("964") Then
                localPhone = "0" & localPhone.Substring(3)
            ElseIf localPhone.StartsWith("7") AndAlso localPhone.Length = 10 Then
                localPhone = "0" & localPhone
            End If

            ' فحص النمط العراقي: 07XXXXXXXXX (11 رقماً)
            Dim match = Regex.Match(localPhone, "^07[3-9]\d{8}$")
            If Not match.Success Then
                result.IsValid = False
                result.ErrorMessage = "رقم الهاتف غير صالح. يجب أن يبدأ بـ 07 ويتكون من 11 رقماً (مثال: 07801234567)."
                Return result
            End If

            ' تحديد شركة الاتصالات
            Dim prefix3 = localPhone.Substring(0, 3)
            Select Case prefix3
                Case "078", "079"
                    result.Carrier = "زين العراق (Zain IQ)"
                Case "077"
                    result.Carrier = "آسيا سيل (Asiacell)"
                Case "075"
                    result.Carrier = "كورك تيليكوم (Korek Telecom)"
                Case "076"
                    result.Carrier = "أمنية العراق (Omnnea)"
                Case "074"
                    result.Carrier = "إتصالنا (Itisaluna)"
                Case Else
                    result.Carrier = "شبكة اتصالات عراقية"
            End Select

            result.IsValid = True
            result.CleanPhone = localPhone
            result.InternationalFormat = "+964" & localPhone.Substring(1)
            Return result
        End Function

        ''' <summary>
        ''' التحقق من الوثائق الرسمية في العراق
        ''' - البطاقة الوطنية الموحدة: 12 رقماً إجبارياً
        ''' - هوية الأحوال المدنية: أرقام مع السجل والصحيفة
        ''' - شهادة الجنسية العراقية أو جواز السفر العراقي (A / G + أرقام)
        ''' </summary>
        Public Shared Function ValidateIdentityDocument(docNumber As String, docType As String) As IdentityValidationResult
            Dim result As New IdentityValidationResult()

            If String.IsNullOrWhiteSpace(docNumber) Then
                result.IsValid = False
                result.ErrorMessage = "رقم الوثيقة الرسمية مطلوب."
                Return result
            End If

            Dim cleaned = docNumber.Trim()

            Select Case docType
                Case "البطاقة الوطنية الموحدة"
                    Dim digitsOnly = Regex.Replace(cleaned, "[^\d]", "")
                    If digitsOnly.Length <> 12 Then
                        result.IsValid = False
                        result.ErrorMessage = "رقم البطاقة الوطنية الموحدة يجب أن يتكون من 12 رقماً تماماً."
                        Return result
                    End If
                    result.IsValid = True

                Case "جواز السفر العراقي"
                    If Not Regex.IsMatch(cleaned, "^[A-Za-z]\d{7,8}$") Then
                        result.IsValid = False
                        result.ErrorMessage = "رقم جواز السفر العراقي يجب أن يبدأ بحرف يليه 7 أو 8 أرقام (مثال: A1234567)."
                        Return result
                    End If
                    result.IsValid = True

                Case Else
                    If cleaned.Length < 6 Then
                        result.IsValid = False
                        result.ErrorMessage = "رقم الوثيقة المدنية قصير جداً (6 خانات على الأقل)."
                        Return result
                    End If
                    result.IsValid = True
            End Select

            Return result
        End Function

        ''' <summary>
        ''' تنسيق المبلغ بالدينار العراقي (IQD - د.ع)
        ''' </summary>
        Public Shared Function FormatIraqiDinar(amount As Decimal) As String
            Return $"{amount:N0} د.ع"
        End Function
    End Class

    Public Class PhoneValidationResult
        Public Property IsValid As Boolean
        Public Property Carrier As String = String.Empty
        Public Property CleanPhone As String = String.Empty
        Public Property InternationalFormat As String = String.Empty
        Public Property ErrorMessage As String = String.Empty
    End Class

    Public Class IdentityValidationResult
        Public Property IsValid As Boolean
        Public Property ErrorMessage As String = String.Empty
    End Class
End Namespace
