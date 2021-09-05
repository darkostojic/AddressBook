#!/bin/bash
set -e
export PGPASSWORD=$POSTGRES_PASSWORD;
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
-- DROP SCHEMA address_book;

CREATE SCHEMA address_book AUTHORIZATION postgres;

-- DROP SEQUENCE address_book.contact_numbers_id_seq;

CREATE SEQUENCE address_book.contact_numbers_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE address_book.contacts_id_seq;

CREATE SEQUENCE address_book.contacts_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- address_book.contacts definition

-- Drop table

-- DROP TABLE address_book.contacts;

CREATE TABLE address_book.contacts (
	id serial NOT NULL,
	"name" varchar NULL,
	date_of_birth date NULL,
	address varchar NULL,
	CONSTRAINT address_un UNIQUE (address),
	CONSTRAINT contacts_pkey PRIMARY KEY (id),
	CONSTRAINT name_un UNIQUE (name)
);


-- address_book.contact_numbers definition

-- Drop table

-- DROP TABLE address_book.contact_numbers;

CREATE TABLE address_book.contact_numbers (
	id serial NOT NULL,
	"number" varchar NOT NULL,
	contact_id int4 NOT NULL,
	CONSTRAINT contact_numbers_pkey PRIMARY KEY (id),
	CONSTRAINT contact_numbers_fk FOREIGN KEY (contact_id) REFERENCES address_book.contacts(id) ON DELETE CASCADE
);

	  COMMIT;
	EOSQL