'use strict';
 
var gulp = require('gulp');
var diff = require('gulp-diff');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var ngAnnotate = require('gulp-ng-annotate');
var bower = require("gulp-bower");
 
gulp.task('default', function () {

    return gulp.src('www/js/*.js')
        .pipe(ngAnnotate())
        .pipe(concat('app.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('www/lib/_app'));

});

gulp.task("bower", function () {
  return bower()
    .pipe(gulp.dest("www/lib/"));
});