CREATE TABLE roles (
    id SERIAL PRIMARY KEY,
    role VARCHAR(50) UNIQUE
);

INSERT INTO roles (id, role) VALUES (1,'user');
INSERT INTO roles (id, role) VALUES (2, 'admin');
INSERT INTO roles (id, role) VALUES (3, 'moderator');

CREATE TABLE auth (
    id SERIAL PRIMARY KEY,
    useruuid UUID UNIQUE NOT NULL, -- Benzersiz kısıtlama ekledik
    email VARCHAR(255) UNIQUE NOT NULL,
    passwordhash VARCHAR(255) NOT NULL,
    email_verified BOOLEAN DEFAULT FALSE,
    last_login TIMESTAMP,
    banned BOOLEAN DEFAULT FALSE,
    role_id INTEGER REFERENCES roles(id),
    CONSTRAINT valid_password CHECK (LENGTH(passwordhash) >= 8)
);

CREATE INDEX idx_auth_useruuid ON auth(useruuid);

CREATE TABLE bans (
    id SERIAL PRIMARY KEY,
    useruuid UUID NOT NULL,
    adminuuid UUID NOT NULL,
    ban_reason TEXT NOT NULL,
    ban_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_bans_useruuid FOREIGN KEY (useruuid) REFERENCES auth(useruuid) ON DELETE CASCADE
);

CREATE INDEX idx_bans_useruuid ON bans (useruuid);
