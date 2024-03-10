-- users tablosu
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    uuid UUID UNIQUE NOT NULL,
    username VARCHAR(255) UNIQUE NOT NULL CHECK (LENGTH(username) <= 50)
);

CREATE INDEX idx_users_uuid ON users (uuid);
CREATE INDEX idx_users_username ON users (username);

-- guilds tablosu
CREATE TABLE guilds (
    id SERIAL PRIMARY KEY,
    uuid UUID UNIQUE NOT NULL,
    guildname VARCHAR(255) NOT NULL,
    guildtype VARCHAR(255) NOT NULL,
    owneruuid UUID REFERENCES users(uuid)
);

CREATE INDEX idx_guilds_uuid ON guilds (uuid);
CREATE INDEX idx_guilds_guildname ON guilds (guildname);

-- channels tablosu
CREATE TABLE channels (
    id SERIAL PRIMARY KEY,
    uuid UUID UNIQUE NOT NULL,
    channelname VARCHAR(255) NOT NULL,
    channeltype VARCHAR(255) NOT NULL,
    parentchannel UUID,
    guilduuid UUID REFERENCES guilds(uuid)
);

CREATE INDEX idx_channels_uuid ON channels (uuid);
CREATE INDEX idx_channels_channelname ON channels (channelname);

-- user_guild_join tablosu
CREATE TABLE user_guild_join (
    id SERIAL PRIMARY KEY,
    useruuid UUID REFERENCES users(uuid),
    guilduuid UUID REFERENCES guilds(uuid)
);

CREATE INDEX idx_user_guild_join_useruuid ON user_guild_join (useruuid);
CREATE INDEX idx_user_guild_join_guilduuid ON user_guild_join (guilduuid);

-- user_friend tablosu
CREATE TABLE user_friend (
    id SERIAL PRIMARY KEY,
    useruuid UUID REFERENCES users(uuid),
    frienduuid UUID REFERENCES users(uuid)
);

CREATE INDEX idx_user_friend_useruuid ON user_friend (useruuid);
CREATE INDEX idx_user_friend_frienduuid ON user_friend (frienduuid);

-- friend_requests tablosu
CREATE TABLE friend_requests (
    id SERIAL PRIMARY KEY,
    useruuid UUID REFERENCES users(uuid),
    senderuuid UUID REFERENCES users(uuid)
    CONSTRAINT unique_friend_request UNIQUE (useruuid, senderuuid) -- Her kullanıcıya bir arkadaşlık isteği gönderilmesini sağladık
);

CREATE INDEX idx_friend_requests_useruuid ON friend_requests (useruuid);
CREATE INDEX idx_friend_requests_senderuuid ON friend_requests (senderuuid);