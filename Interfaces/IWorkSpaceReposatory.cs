namespace CoWorkSpace.Interfaces
{
    public interface IWorkSpaceReposatory 
    {
          Task RegisterWorkSpace();
          Task EditWorkSpace();
          Task DeleteWorkSpace();
          Task GetWorkSpace();
          Task ReserveWorkSpace();
         

        
    }
}