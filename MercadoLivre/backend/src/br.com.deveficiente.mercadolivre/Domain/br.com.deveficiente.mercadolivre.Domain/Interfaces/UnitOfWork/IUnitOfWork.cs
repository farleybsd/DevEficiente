﻿using br.com.deveficiente.mercadolivre.Domain.Interfaces.Repository;

namespace br.com.deveficiente.mercadolivre.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        bool Commit();
        void Rollback();
        ILoginRepository LoginRepository { get; }
    }
}