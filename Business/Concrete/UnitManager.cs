using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UnitManager : IUnitService
    {
        IUnitDal _unitDal;

        public UnitManager(IUnitDal unitDal)
        {
            _unitDal = unitDal;
        }

        public IResult Add(Unit unit)
        {
            IResult result = BusinessRules.Run(CheckIfUnitNameExists(unit.UnitName));

            if (result != null)
            {
                return result;

            }
            _unitDal.Add(unit);
            return new SuccessResult(Messages.UnitAddedMessage);
        }

        public IResult Delete(Unit unit)
        {
            _unitDal.Delete(unit);
            return new SuccessResult(Messages.UnitNameDeleted);
        }

        public IDataResult<List<Unit>> GetAll()
        {
            return new SuccessDataResult<List<Unit>>(_unitDal.GetAll().ToList());
        }

        public IDataResult<Unit> GetById(int unitId)
        {
            return new SuccessDataResult<Unit>(_unitDal.Get(c => c.UnitId == unitId));
        }

        public IResult Update(Unit unit)
        {
            _unitDal.Update(unit);
            return new SuccessResult(Messages.UnitNameUpdated);
        }

        private IResult CheckIfUnitNameExists(string unitName)
        {
            var result = _unitDal.GetAll(c => c.UnitName == unitName).ToList().Any();
            if (result)
            {
                return new ErrorResult(Messages.UnitNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
