var gulp = require('gulp');
var less = require('gulp-less');
var autoprefixer = require('gulp-autoprefixer');
var mincss = require("gulp-minify-css");
var sourcemaps = require('gulp-sourcemaps');
var babel = require('gulp-babel');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var pkg = require("./package.json");

gulp.task("css", function () {
    gulp.src(pkg.cssfiles)
        .pipe(sourcemaps.init())
        .pipe(less())
        .pipe(concat("styles.css"))
        .pipe(mincss())
        .pipe(autoprefixer({ map: true }))
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest("./content"));
});

gulp.task("js", function () {
    gulp.src(pkg.jsfiles)
        .pipe(sourcemaps.init())
        .pipe(concat("app.min.js"))
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest("Scripts"));
});

gulp.task("watch", function() {
    gulp.watch(pkg.jsFilesPath, ["js"]);
});

gulp.task("default", ["css", "js"]);