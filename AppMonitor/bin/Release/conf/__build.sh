#!/bin/bash
SOURCE=_sourcePath_/_projectName_
cd $SOURCE
svn up
mvn -Pdev clean package  -DskipTests=true
