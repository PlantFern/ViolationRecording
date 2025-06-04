

using Microsoft.EntityFrameworkCore;
using ViolationsRecording.Models.Entities;
using ViolationsRecording.Models.Reports;

namespace ViolationsRecording.Controllers;

public partial class ViolationsRecordingController
{
    #region Вспомогательные выборки и сортировки
    public List<string> GetBrandNames() =>
        db
        .Brands
        .Select(b => b.Name)
        .ToList();
    public List<string> GetModelNamesWithBrand(string brand) =>
        db
        .Models
        .Where(m => m.Brand.Name.Equals(brand))
        .Select(m => m.Name)
        .ToList();
    public List<string> GetColorNames() =>
        db
        .Colors
        .Select(c => c.Name)
        .ToList();
    public List<string> GetPassports() =>
        db
        .Persons
        .Select(p => p.Passport)
        .ToList();
    #endregion


    #region Запросы по заданию
    /*
     * Выбирает информацию об автомобилях заданной 
     * модели, производителя и цвета.
     * Сортировка по полю Госномер автомобиля.
     */
    public List<CarDTO> GetCarsWithBrandAndModelAndColor(string brand, string model, string color) =>
        db
        .Cars
        .Where(c => c.Model.Brand.Name.Equals(brand) &&
                    c.Model.Name.Equals(model) &&
                    c.Color.Name.Equals(color))
        .Select(c => new CarDTO { 
                    Brand = c.Model.Brand.Name
                    , Model = c.Model.Name
                    , ProductionYear = c.ProductionYear
                    , Color = c.Color.Name
                    , StateNumber = c.StateNumber.StateNumberName
                    , InsuranceCost = c.InsuranceCost})
        .OrderBy(c => c.StateNumber)
        .ToList();

    /* 
     * Выбирает информацию о владельцах автомобилей, 
     * видах нарушений ПДД, размер штрафа за которые 
     * составляет не менее заданной суммы.
     * Сортировка по убыванию поля Размер штрафа.
     */
    public List<CarOwnerWithViolantialType> GetViolationalFactWithFineMoreThan(double fineAmount) =>
        db
        .ViolationFacts
        .Where(v => v.ViolationType.FineAmount >= fineAmount)
        .Select(v => new CarOwnerWithViolantialType {
                     FullName = v.Driver.Person.FullName
                     , Passport = v.Driver.Person.Passport
                     , ViolationType = v.ViolationType.Name
                     , FineAmount = v.ViolationType.FineAmount})
        .OrderBy(v => v.FineAmount)
        .ToList();

    /* 
     * Выбирает информацию о видах нарушений ПДД,
     * совершенных водителем с заданным паспортом. 
     * Сортировка по убыванию поля Размер штрафа.
     */
    public List<ViolationTypeDTO> GetViolationTypeByPassport(string passport) =>
        db
        .ViolationFacts
        .Where(v => v.Driver.Person.Passport.Equals(passport))
        .Select(v => new ViolationTypeDTO{
                    Name = v.ViolationType.Name
                    , FineAmount = v.ViolationType.FineAmount
                    })
        .OrderByDescending(v => v.FineAmount)
        .ToList();

    /* 
     * Выбирает информацию об автомобилях, 
     * совершивших нарушение в заданный период. 
     */
    public List<CarDTO> GetCarByFixationDateInRange(DateTime lo, DateTime hi) =>
        db
        .ViolationFacts
        .Where(v => v.FixationDate >= lo && v.FixationDate <= hi)
        .Select(v => new CarDTO {
                    Brand = v.Car.Model.Brand.Name
                    , Model = v.Car.Model.Name
                    , Color = v.Car.Color.Name
                    , ProductionYear = v.Car.ProductionYear
                    , StateNumber = v.Car.StateNumber.StateNumberName
                    , InsuranceCost = v.Car.InsuranceCost })
        .ToList();

    /* 
     * Выбирает информацию обо всех зафиксированных 
     * фактах нарушения ПДД (Дата нарушения, ФИО водителя,
     * Госномер автомобиля, Год выпуска автомобиля, 
     * Наименование нарушения) для автомобилей со 
     * значениями в поле Год выпуска автомобиля из 
     * заданного диапазона. 
     * Сортировка по полю Год выпуска автомобиля.
     */
    public List<ViolationFactByProductionYear> GetViolationTypeByProductionYear(int lo, int hi) =>
        db
        .ViolationFacts
        .Where(v => v.Car.ProductionYear >= lo &&
                    v.Car.ProductionYear <= hi)
        .Select(v => new ViolationFactByProductionYear {
                    FixationDate = v.FixationDate
                    , FullName = v.Driver.Person.FullName
                    , StateNumber = v.Car.StateNumber.StateNumberName
                    , ProductionYear = v.Car.ProductionYear
                    , ViolationType = v.ViolationType.Name})
        .OrderBy(v => v.ProductionYear)
        .ToList();

    /* 
     * Вычисляет для каждого автомобиля величину 
     * страхового взноса. Включает все поля таблицы 
     * АВТОМОБИЛИ. 
     * Сортировка по полю ФИО владельца автомобиля.
     */
    public List<CarWithInsuranceCapitalAmount> GetCarWithInsuranceCapitalAmount() =>
        db
        .Cars
        .Select(c => new CarWithInsuranceCapitalAmount {
                    FullName = c.Owner.FullName
                    , Brand = c.Model.Brand.Name
                    , Model = c.Model.Name
                    , Color = c.Color.Name
                    , ProductionYear = c.ProductionYear
                    , StateNumber = c.StateNumber.StateNumberName
                    , InsuranceCost = c.InsuranceCost
                    , InsuranceCapitalAmount = c.InsuranceCost / (100.0 * 10)})
        .ToList()
        .OrderBy(c => c.FullName)
        .ToList();

    /* 
     * Группировка по регистрационным номерам 
     * автомобилей, определите количество нарушений 
     * ПДД, суммарный штраф. 
     * Упорядочить по суммарному штрафу.
     */
    public List<ViolationsByStateNumber> GetGroupByStateNumberWithViolationAmountAndFine() =>
        db
        .ViolationFacts
        .GroupBy(v => new { stateNumber = v.Car.StateNumber.StateNumberName })
        .Select(v => new ViolationsByStateNumber{
            StateNumber = v.Key.stateNumber
            , ViolationsCount = v.Count()
            , TotalFineAmount = v.Sum(v => v.ViolationType.FineAmount)
        })
        .OrderBy(v => v.TotalFineAmount)
        .ToList();

    /* 
     * Для всех видов нарушения, определите 
     * количество нарушений. 
     * Упорядочить по виду нарушений.
     */
    public List<ViolationTypeAmount> Query8() =>
        db
        .Database
        .SqlQuery<ViolationTypeAmount>(
            $"""
            SELECT 
                ViolationTypes.Name,
                COUNT(ViolationFacts.Id) AS ViolationCount
            FROM 
                ViolationTypes
            LEFT JOIN 
                ViolationFacts ON ViolationFacts.ViolationTypeId = ViolationTypes.Id
            GROUP BY 
                ViolationTypes.Name
            ORDER BY 
                ViolationTypes.Name;
            """
            )
        .ToList();

    /* 
     * Для всех водителей (персон, имеющих право 
     * на управление транспортным средством), 
     * зарегистрированных в системе учета, 
     * определите количество нарушений,
     * минимальный, средний и максимальный штраф, 
     * сумму штрафов. 
     * Упорядочить по убыванию суммы штрафов.
     */
    public List<ViolationTypeAmountWithFineAmount> Query9() =>
        db
        .Database
        .SqlQuery<ViolationTypeAmountWithFineAmount>(
        $"""
            SELECT 
                (Persons.Surname + ' ' + Persons.Name + ' ' + Persons.Patronymic) AS Name,
                COUNT(ViolationFacts.Id) AS ViolationCount,
                ISNULL(MIN(ViolationTypes.FineAmount), 0) AS FineAmountMin,
                ISNULL(MAX(ViolationTypes.FineAmount), 0) AS FineAmountMax,
                ISNULL(AVG(ViolationTypes.FineAmount), 0) AS FineAmountAverage,
                ISNULL(SUM(ViolationTypes.FineAmount), 0) AS FineAmountTotal
            FROM 
                CarOwners
            JOIN 
                Persons ON CarOwners.DriverId = Persons.Id
            LEFT JOIN 
                ViolationFacts ON ViolationFacts.CarOwnerId = CarOwners.Id
            LEFT JOIN 
                ViolationTypes ON ViolationFacts.ViolationTypeId = ViolationTypes.Id
            GROUP BY 
                Persons.Surname, Persons.Name, Persons.Patronymic
            ORDER BY 
                ISNULL(SUM(ViolationTypes.FineAmount), 0) DESC;
        """
            )
        .ToList();

    #endregion
}
