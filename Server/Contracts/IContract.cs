using System.Collections.Generic;
using System.ServiceModel;

[ServiceContract]
interface IContract<T>
{
    // Reading data
    [OperationContract]
    T Read(int ID);
    [OperationContract]
    List<T> ReadAll();

    // Adding data
    [OperationContract]
    bool Create(T entity);

    // Updating data
    [OperationContract]
    bool Update(int updatingID, T newEntity);

    // Deleting data
    [OperationContract]
    bool Delete(int ID);
}