# Introduction

This is my Record Database. It contains all the code to display a listing my my CD's, Blurays and vinyl Records. It has a number of routines to add, update and delete albums in the database.

The RecordDB consists of three parts.

## RecordDAL

Is the database backend. It contains the routines to get and push new data to and from the database. This version uses Dapper as the Orm.

## RecordDB

Is the ASP.Net Web Forms browser application that displays the data and contains forms to display and update the data. It retrieves its data from ``RecordDAL``.

## RecordTest

Is the testing backend for the data routines. This is a console program that I use to create and test routines for data access. The code from here eventually makes its way in to ``RecordDB``.

## Getting Started

Most of the code has been completed but each year I have to maintain some of the page displays based on the years I bought the albums.

In the RecordDB project there is a text file named ``Updates.txt`` that contains all of the code that I have to update in the ``RecordDB`` website application.

Once I update the website application I update the text file with next years updates.

## Future Tasks

Eventually I will need to update this application to add a REST API for data access.
