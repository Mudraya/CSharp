/*==============================================================*/
/* DBMS name:      ADABAS D                                     */
/* Created on:     Вс 09.12.18 0:59:34                          */
/*==============================================================*/


drop table BOOKS_IN_LIBRARY;

--drop table BOUGHT_BOOKS;

--drop table SERVICING_TO_USERS;

drop table HALL;

drop table LIBRARIES;

drop table PAID_BOOKS;

drop table SERVICES;

drop table SUBSCRIPTION;


/*==============================================================*/
/* Table: LIBRARY                                               */
/*==============================================================*/
create table LIBRARIES (
ID_LIBRARY int CONSTRAINT ID_LIBRARY_PK PRIMARY KEY,
LIBRARY_ADRESS NVARCHAR(100),
TOTAL_READERS int,
TOTAL_BOOKS int,
TOTAL_USE_BOOKS int
);

/*==============================================================*/
/* Table: HALL                                                  */
/*==============================================================*/
create table HALL (
ID_HALL int CONSTRAINT ID_HALL_PK PRIMARY KEY,
TOTAL_PLACE int,
TOTAL_BOOKS int,
ID_LIBRARY int,CONSTRAINT FK_ID_LIBRARY_H
                                    FOREIGN KEY (ID_LIBRARY)
                                    REFERENCES LIBRARIES(ID_LIBRARY),
HALL_NAME NVARCHAR(100)
);

/*==============================================================*/
/* Table: PAID_BOOKS                                            */
/*==============================================================*/
create table PAID_BOOKS (
ID_BOOK int CONSTRAINT ID_BOOK_PK PRIMARY KEY,
BOOK_NAME NVARCHAR(100),
BOOK_PRICE NVARCHAR(100)
);

/*==============================================================*/
/* Table: SERVICES                                              */
/*==============================================================*/
create table SERVICES (
ID_SERVICE int CONSTRAINT ID_SERVICE_PK PRIMARY KEY,
SERVICE_NAME NVARCHAR(100),
SERVICE_PRICE int
);

/*==============================================================*/
/* Table: SUBSCRIPTION                                          */
/*==============================================================*/
create table SUBSCRIPTION (
ID_SUBSCRIPTION int CONSTRAINT ID_SUBSCRIPTION_PK PRIMARY KEY,
TOTAL_BOOKS int,
ID_LIBRARY int,
USER_NAME NVARCHAR(100)
);

/*==============================================================*/
/* Table: SERVICING_TO_USERS                                    */
/*==============================================================*/
/*create table SERVICING_TO_USERS (
ID_SUBSCRIPTION , CONSTRAINT FK_ID_SUBSCRIPTION_SU
                                    FOREIGN KEY (ID_SUBSCRIPTION)
                                    REFERENCES SUBSCRIPTION(ID_SUBSCRIPTION),
ID_SERVICE , CONSTRAINT FK_ID_SERVICE_SU
                                    FOREIGN KEY (ID_SERVICE)
                                    REFERENCES SERVICES(ID_SERVICE),
TOTAL_COST NUMBER(4),
SERVICING_DATE DATE
);*/

/*==============================================================*/
/* Table: BOOKS_IN_LIBRARY                                      */
/*==============================================================*/
create table BOOKS_IN_LIBRARY (
ID_LIBRARY int, CONSTRAINT FK_ID_LIBRARY_BL
                                    FOREIGN KEY (ID_LIBRARY)
                                    REFERENCES LIBRARIES(ID_LIBRARY),
ID_BOOK int, CONSTRAINT FK_ID_BOOK_BL
                                    FOREIGN KEY (ID_BOOK)
                                    REFERENCES PAID_BOOKS(ID_BOOK),
QUANTITY int
);

/*==============================================================*/
/* Table: BOUGHT_BOOKS                                          */
/*==============================================================*/
/*create table BOUGHT_BOOKS (
ID_BOOK , CONSTRAINT FK_ID_BOOK_BB
                                    FOREIGN KEY (ID_BOOK)
                                    REFERENCES PAID_BOOKS(ID_BOOK),
ID_SUBSCRIPTION , CONSTRAINT FK_ID_SUBSCRIPTION_BB
                                    FOREIGN KEY (ID_SUBSCRIPTION)
                                    REFERENCES SUBSCRIPTION(ID_SUBSCRIPTION),
QUANTITY NUMBER(4),
PURCHASE_DATE DATE
);*/
