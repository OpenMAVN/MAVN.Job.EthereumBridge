﻿using System.Threading.Tasks;
using MAVN.Job.EthereumBridge.Domain.Repositories;
using MAVN.Job.EthereumBridge.MsSqlRepositories.Constants;
using MAVN.Job.EthereumBridge.MsSqlRepositories.Entities;
using MAVN.Persistence.PostgreSQL.Legacy;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Job.EthereumBridge.MsSqlRepositories.Repositories
{
    public class IndexingStateRepository : IIndexingStateRepository
    {
        private readonly IDbContextFactory<EthereumBridgeContext> _contextFactory;

        public IndexingStateRepository(
            IDbContextFactory<EthereumBridgeContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<long?> GetLastIndexedBlockNumberAsync()
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var lastIndexedBlock = await context.BlocksData
                    .SingleOrDefaultAsync(b => b.Key == BlocksDataKeys.LastIndexedBlockNumberKey);

                if (lastIndexedBlock == null)
                    return null;

                return long.Parse(lastIndexedBlock.Value);
            }
        }

        public async Task SaveLastIndexedBlockNumber(long blockNumber)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var existingEntity = await context
                    .BlocksData
                    .SingleOrDefaultAsync(b => b.Key == BlocksDataKeys.LastIndexedBlockNumberKey);

                if (existingEntity != null)
                {
                    existingEntity.Value = blockNumber.ToString();
                    context.Update(existingEntity);
                }
                else
                {
                    var newEntity = new BlocksDataEntity
                    {
                        Key = BlocksDataKeys.LastIndexedBlockNumberKey,
                        Value = blockNumber.ToString()
                    };
                    context.Add(newEntity);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
