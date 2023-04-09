using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public IResult Add(Branch branch)
        {
            IResult result = BusinessRules.Run(CheckIfBranchNameExists(branch.BranchCityName));

            if (result != null)
            {
                return result;

            }
            _branchDal.Add(branch);
            return new SuccessResult(Messages.BranchAddedMessage);
        }

        public IResult Delete(Branch branch)
        {
            _branchDal.Delete(branch);
            return new SuccessResult(Messages.BranchNameDeleted);
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll().ToList());
        }

        public IDataResult<Branch> GetById(int branchId)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(c => c.BranchId == branchId));
        }

        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessResult(Messages.BranchNameUpdated);
        }

        private IResult CheckIfBranchNameExists(string branchName)
        {
            var result = _branchDal.GetAll(c => c.BranchCityName == branchName).ToList().Any();
            if (result)
            {
                return new ErrorResult(Messages.BranchNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
