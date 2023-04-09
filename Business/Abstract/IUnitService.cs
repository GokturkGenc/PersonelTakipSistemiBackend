using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUnitService
    {
        IDataResult<List<Unit>> GetAll();
        IDataResult<Unit> GetById(int unitId);
        IResult Add(Unit unit);
        IResult Delete(Unit unit);
        IResult Update(Unit unit);
    }
}
