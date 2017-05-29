
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/22/2017 19:51:12
-- Generated from EDMX file: C:\Schedule\SheduleEF\SheduleEF\Shed.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sheadule];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GROUPS_FACULTY]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GROUPS] DROP CONSTRAINT [FK_GROUPS_FACULTY];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_ACTIVITY]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_ACTIVITY];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_AUDITORIUM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_AUDITORIUM];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_DISCIPLINE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_DISCIPLINE];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_GROUPS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_GROUPS];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_TEACHER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_TEACHER];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_TIME]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_TIME];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_TYPE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_TYPE];
GO
IF OBJECT_ID(N'[dbo].[FK_TIMETABLE_WEEKDAY]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TIMETABLE] DROP CONSTRAINT [FK_TIMETABLE_WEEKDAY];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ACTIVITY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ACTIVITY];
GO
IF OBJECT_ID(N'[dbo].[AUDITORIUM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AUDITORIUM];
GO
IF OBJECT_ID(N'[dbo].[DISCIPLINE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DISCIPLINE];
GO
IF OBJECT_ID(N'[dbo].[FACULTY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FACULTY];
GO
IF OBJECT_ID(N'[dbo].[GROUPS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GROUPS];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TEACHER]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TEACHER];
GO
IF OBJECT_ID(N'[dbo].[TIME]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TIME];
GO
IF OBJECT_ID(N'[dbo].[TIMETABLE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TIMETABLE];
GO
IF OBJECT_ID(N'[dbo].[TYPE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TYPE];
GO
IF OBJECT_ID(N'[dbo].[WEEKDAY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WEEKDAY];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ACTIVITY'
CREATE TABLE [dbo].[ACTIVITY] (
    [ACTIVITY_TYPE_CODE] int IDENTITY(1,1) NOT NULL,
    [ACTIVITY_TYPE_NAME] varchar(50)  NULL
);
GO

-- Creating table 'AUDITORIUM'
CREATE TABLE [dbo].[AUDITORIUM] (
    [AUDITORIUM_CODE] int IDENTITY(1,1) NOT NULL,
    [BUILDING] varchar(50)  NULL,
    [CAPACITY] int  NULL,
    [AUDITORIUM_NUMBER] varchar(10)  NULL
);
GO

-- Creating table 'DISCIPLINE'
CREATE TABLE [dbo].[DISCIPLINE] (
    [DISCIPLINE_CODE] int IDENTITY(1,1) NOT NULL,
    [DISCIPLINE_NAME] varchar(100)  NULL
);
GO

-- Creating table 'FACULTY'
CREATE TABLE [dbo].[FACULTY] (
    [FACULTY_CODE] int IDENTITY(1,1) NOT NULL,
    [FACULTY_NAME] varchar(150)  NULL
);
GO

-- Creating table 'GROUPS'
CREATE TABLE [dbo].[GROUPS] (
    [GROUP_CODE] int IDENTITY(1,1) NOT NULL,
    [FACULTY_CODE] int  NULL,
    [GROUP_NUMBER] varchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TEACHER'
CREATE TABLE [dbo].[TEACHER] (
    [TEACHER_CODE] int IDENTITY(1,1) NOT NULL,
    [TEACHER_NAME] varchar(100)  NULL
);
GO

-- Creating table 'TIME'
CREATE TABLE [dbo].[TIME] (
    [TIME_CODE] int IDENTITY(1,1) NOT NULL,
    [TIME_START] varchar(50)  NULL,
    [TIME_END] varchar(50)  NULL
);
GO

-- Creating table 'TIMETABLE'
CREATE TABLE [dbo].[TIMETABLE] (
    [LESSON_CODE] int IDENTITY(1,1) NOT NULL,
    [WEEKDAY_CODE] int  NULL,
    [COURSE_CODE] int  NULL,
    [GROUP_CODE] int  NULL,
    [TEACHER_CODE] int  NULL,
    [DISCIPLINE_CODE] int  NULL,
    [ACTIVITY_TYPE_CODE] int  NULL,
    [AUDITORIUM_CODE] int  NULL,
    [WEEK_NUMBER] int  NULL,
    [TIME_CODE] int  NULL,
    [CROSSES] int  NULL,
    [TYPE_CODE] int  NULL
);
GO

-- Creating table 'TYPE'
CREATE TABLE [dbo].[TYPE] (
    [TYPE_CODE] int IDENTITY(1,1) NOT NULL,
    [TYPE_NAME] nchar(50)  NOT NULL,
    [TYPE_TIME_START] datetime  NULL,
    [TYPE_TIME_END] datetime  NULL
);
GO

-- Creating table 'WEEKDAY'
CREATE TABLE [dbo].[WEEKDAY] (
    [WEEKDAY_CODE] int IDENTITY(1,1) NOT NULL,
    [WEEKDAY_NAME] varchar(15)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ACTIVITY_TYPE_CODE] in table 'ACTIVITY'
ALTER TABLE [dbo].[ACTIVITY]
ADD CONSTRAINT [PK_ACTIVITY]
    PRIMARY KEY CLUSTERED ([ACTIVITY_TYPE_CODE] ASC);
GO

-- Creating primary key on [AUDITORIUM_CODE] in table 'AUDITORIUM'
ALTER TABLE [dbo].[AUDITORIUM]
ADD CONSTRAINT [PK_AUDITORIUM]
    PRIMARY KEY CLUSTERED ([AUDITORIUM_CODE] ASC);
GO

-- Creating primary key on [DISCIPLINE_CODE] in table 'DISCIPLINE'
ALTER TABLE [dbo].[DISCIPLINE]
ADD CONSTRAINT [PK_DISCIPLINE]
    PRIMARY KEY CLUSTERED ([DISCIPLINE_CODE] ASC);
GO

-- Creating primary key on [FACULTY_CODE] in table 'FACULTY'
ALTER TABLE [dbo].[FACULTY]
ADD CONSTRAINT [PK_FACULTY]
    PRIMARY KEY CLUSTERED ([FACULTY_CODE] ASC);
GO

-- Creating primary key on [GROUP_CODE] in table 'GROUPS'
ALTER TABLE [dbo].[GROUPS]
ADD CONSTRAINT [PK_GROUPS]
    PRIMARY KEY CLUSTERED ([GROUP_CODE] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TEACHER_CODE] in table 'TEACHER'
ALTER TABLE [dbo].[TEACHER]
ADD CONSTRAINT [PK_TEACHER]
    PRIMARY KEY CLUSTERED ([TEACHER_CODE] ASC);
GO

-- Creating primary key on [TIME_CODE] in table 'TIME'
ALTER TABLE [dbo].[TIME]
ADD CONSTRAINT [PK_TIME]
    PRIMARY KEY CLUSTERED ([TIME_CODE] ASC);
GO

-- Creating primary key on [LESSON_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [PK_TIMETABLE]
    PRIMARY KEY CLUSTERED ([LESSON_CODE] ASC);
GO

-- Creating primary key on [TYPE_CODE] in table 'TYPE'
ALTER TABLE [dbo].[TYPE]
ADD CONSTRAINT [PK_TYPE]
    PRIMARY KEY CLUSTERED ([TYPE_CODE] ASC);
GO

-- Creating primary key on [WEEKDAY_CODE] in table 'WEEKDAY'
ALTER TABLE [dbo].[WEEKDAY]
ADD CONSTRAINT [PK_WEEKDAY]
    PRIMARY KEY CLUSTERED ([WEEKDAY_CODE] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ACTIVITY_TYPE_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_ACTIVITY]
    FOREIGN KEY ([ACTIVITY_TYPE_CODE])
    REFERENCES [dbo].[ACTIVITY]
        ([ACTIVITY_TYPE_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_ACTIVITY'
CREATE INDEX [IX_FK_TIMETABLE_ACTIVITY]
ON [dbo].[TIMETABLE]
    ([ACTIVITY_TYPE_CODE]);
GO

-- Creating foreign key on [AUDITORIUM_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_AUDITORIUM]
    FOREIGN KEY ([AUDITORIUM_CODE])
    REFERENCES [dbo].[AUDITORIUM]
        ([AUDITORIUM_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_AUDITORIUM'
CREATE INDEX [IX_FK_TIMETABLE_AUDITORIUM]
ON [dbo].[TIMETABLE]
    ([AUDITORIUM_CODE]);
GO

-- Creating foreign key on [DISCIPLINE_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_DISCIPLINE]
    FOREIGN KEY ([DISCIPLINE_CODE])
    REFERENCES [dbo].[DISCIPLINE]
        ([DISCIPLINE_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_DISCIPLINE'
CREATE INDEX [IX_FK_TIMETABLE_DISCIPLINE]
ON [dbo].[TIMETABLE]
    ([DISCIPLINE_CODE]);
GO

-- Creating foreign key on [FACULTY_CODE] in table 'GROUPS'
ALTER TABLE [dbo].[GROUPS]
ADD CONSTRAINT [FK_GROUPS_FACULTY]
    FOREIGN KEY ([FACULTY_CODE])
    REFERENCES [dbo].[FACULTY]
        ([FACULTY_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GROUPS_FACULTY'
CREATE INDEX [IX_FK_GROUPS_FACULTY]
ON [dbo].[GROUPS]
    ([FACULTY_CODE]);
GO

-- Creating foreign key on [GROUP_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_GROUPS]
    FOREIGN KEY ([GROUP_CODE])
    REFERENCES [dbo].[GROUPS]
        ([GROUP_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_GROUPS'
CREATE INDEX [IX_FK_TIMETABLE_GROUPS]
ON [dbo].[TIMETABLE]
    ([GROUP_CODE]);
GO

-- Creating foreign key on [TEACHER_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_TEACHER]
    FOREIGN KEY ([TEACHER_CODE])
    REFERENCES [dbo].[TEACHER]
        ([TEACHER_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_TEACHER'
CREATE INDEX [IX_FK_TIMETABLE_TEACHER]
ON [dbo].[TIMETABLE]
    ([TEACHER_CODE]);
GO

-- Creating foreign key on [TIME_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_TIME]
    FOREIGN KEY ([TIME_CODE])
    REFERENCES [dbo].[TIME]
        ([TIME_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_TIME'
CREATE INDEX [IX_FK_TIMETABLE_TIME]
ON [dbo].[TIMETABLE]
    ([TIME_CODE]);
GO

-- Creating foreign key on [TYPE_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_TYPE]
    FOREIGN KEY ([TYPE_CODE])
    REFERENCES [dbo].[TYPE]
        ([TYPE_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_TYPE'
CREATE INDEX [IX_FK_TIMETABLE_TYPE]
ON [dbo].[TIMETABLE]
    ([TYPE_CODE]);
GO

-- Creating foreign key on [WEEKDAY_CODE] in table 'TIMETABLE'
ALTER TABLE [dbo].[TIMETABLE]
ADD CONSTRAINT [FK_TIMETABLE_WEEKDAY]
    FOREIGN KEY ([WEEKDAY_CODE])
    REFERENCES [dbo].[WEEKDAY]
        ([WEEKDAY_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TIMETABLE_WEEKDAY'
CREATE INDEX [IX_FK_TIMETABLE_WEEKDAY]
ON [dbo].[TIMETABLE]
    ([WEEKDAY_CODE]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------