CREATE TABLE [dbo].[Rents] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [startDate] DATETIME       NOT NULL,
    [endDate]   DATETIME       NOT NULL,
    [Amount]    NVARCHAR (MAX) NULL,
    [tenantId]  INT            NOT NULL,
    [unitId]    INT            NOT NULL,
    [stateId]   INT            NOT NULL,
    CONSTRAINT [PK_dbo.Rents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Rents_dbo.Units_unitId] FOREIGN KEY ([unitId]) REFERENCES [dbo].[Units] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Rents_dbo.Tenants_tenantId] FOREIGN KEY ([tenantId]) REFERENCES [dbo].[Tenants] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Rents_dbo.States_stateId] FOREIGN KEY ([stateId]) REFERENCES [dbo].[States] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_tenantId]
    ON [dbo].[Rents]([tenantId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_unitId]
    ON [dbo].[Rents]([unitId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_stateId]
    ON [dbo].[Rents]([stateId] ASC);

