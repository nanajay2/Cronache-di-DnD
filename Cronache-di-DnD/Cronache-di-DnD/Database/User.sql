CREATE TABLE IF NOT EXISTS Users (
    Id          TEXT PRIMARY KEY NOT NULL,
    Name        TEXT NOT NULL,
    Surname     TEXT NOT NULL,
    Email       TEXT NOT NULL,
    DM          INTEGER NOT NULL,
);