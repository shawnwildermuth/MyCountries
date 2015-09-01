'use strict';
 
var gulp = require('gulp');
var diff = require('gulp-diff');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var ngAnnotate = require('gulp-ng-annotate');
 
gulp.task('default', function () {

    return gulp.src('wwwroot/js/*.js')
        .pipe(ngAnnotate())
        .pipe(concat('app.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('wwwroot/lib/_app'));

});

