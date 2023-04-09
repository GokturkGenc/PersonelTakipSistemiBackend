using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Drawing;
using Task = Entities.Concrete.Task;

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        ITaskDal _taskDal;

        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }
    
        public IResult Add(Task task)
        {
            IResult result = BusinessRules.Run(CheckIfTaskNameExists(task.TaskName));

            if (result != null)
            {
                return result;

            }
            _taskDal.Add(task);
            return new SuccessResult(Messages.TaskAddedMessage);
        }

        public IResult Delete(Task task)
        {
            _taskDal.Delete(task);
            return new SuccessResult(Messages.TaskNameDeleted);
        }

        public IDataResult<List<Task>> GetAll()
        {
            return new SuccessDataResult<List<Task>>(_taskDal.GetAll().ToList());
        }

        public IDataResult<Task> GetById(int taskId)
        {
            return new SuccessDataResult<Task>(_taskDal.Get(c => c.TaskId == taskId));
        }

        public IResult Update(Task task)
        {
            _taskDal.Update(task);
            return new SuccessResult(Messages.TaskNameUpdated);
        }

        private IResult CheckIfTaskNameExists(string taskName)
        {
            var result = _taskDal.GetAll(c => c.TaskName == taskName).ToList().Any();
            if (result)
            {
                return new ErrorResult(Messages.TaskNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
