'use strict'
const path = require('path')
const defaultSettings = require('./src/settings.js')

function resolve(dir) {
  return path.join(__dirname, dir)
}

const name = defaultSettings.title || 'vue Admin Template' // page title

// If your port is set to 80,
// use administrator privileges to execute the command line.
// For example, Mac: sudo npm run
// You can change the port by the following methods:
// port = 9528 npm run dev OR npm run dev --port = 9528
const port = process.env.port || process.env.npm_config_port || 13000 //dev port


// All configuration item explanations can be find in https://cli.vuejs.org/config/
module.exports = {
  /**
   * The base URL your application bundle will be deployed at (known as baseUrl before Vue CLI 3.3).
   * You will need to set publicPath if you plan to deploy your site under a sub path,
   * for example GitHub Pages. If you plan to deploy your site to https://foo.github.io/bar/,
   * then publicPath should be set to "/bar/".
   * In most cases please use '/' !!!
   * Detail: https://cli.vuejs.org/config/#publicpath
   */
  publicPath: '/',
  // The directory where the production build files will be generated in when running vue-cli-service build. Note the target directory will be removed before building (this behavior can be disabled by passing --no-clean when building).
  outputDir: 'dist',
  // A directory (relative to outputDir) to nest generated static assets (js, css, img, fonts) under.
  assertsDir: 'static',
  // process.env.NODE_ENV === 'development' 
  lintOnSave: process.env.NODE_ENV === 'development',
  // Setting this to false can speed up production builds if you don't need source maps for production.
  productionSourceMap: false,
  // All options for webpack-dev-server are supported.
  devServer: {
    port: port,
    open: true,
    overlay: {
      warnings: false,
      errors: true
    },
    before: require('./mock/mock-server.js')
  },
  configureWebpack: {
    // provide the app's title in webpack's name field, so that
    // it can be accessed in index.html to inject the correct title.
    name: name,
    resolve: {
      alias: {
        '@': resolve('src')
      }
    }
  },
  chainWebpack(config) {
    // it can improve the speed of the first screen, it is recommended to turn on preload
    config.plugin('preload').tap(() => [{
      rel: 'preload',
      // to ignore runtime.js
      // https://github.com/vuejs/vue-cli/blob/dev/packages/@vue/cli-service/lib/config/app.js#L171
      fileBlacklist: [/\.map$/, /hot-update\.js$/, /runtime\..*\.js$/],
      include: 'initial'
    }]);

    // when there are many pages, it will cause too many meaningless requests
    config.plugins.delete('prefetch');
  }
};
