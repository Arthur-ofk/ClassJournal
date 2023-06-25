namespace Contracts
{
    public interface IRepositoryManager
    {

        IGroupRepository Group { get; }
        IStudentRepository Student { get; }
        IMarkRepository Mark { get; }

        ISubjectRepository Subject { get; }




        void Save();
    }
}

