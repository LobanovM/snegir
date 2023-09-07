const path = require("path");
const autoprefixer = require('autoprefixer');

module.exports = {
    mode: "development",
    entry: "./app/index.js", // ������� ����� - �������� ����
    output: {
        path: path.resolve(__dirname, "./public"),     // ���� � �������� �������� ������ - ����� public
        publicPath: "/public/",
        filename: "bundle.js"       // �������� ������������ �����
    },
    devServer: {
        historyApiFallback: true,
        static: {
            directory: path.join(__dirname, "/"),
        },
        port: 8081,
        open: true
    },
    module: {
        rules: [   //��������� ��� jsx
            {
                test: /\.jsx?$/, // ���������� ��� ������
                exclude: /(node_modules)/,  // ��������� �� ��������� ����� node_modules
                loader: "babel-loader",   // ���������� ���������
                options: {
                    presets: ["@babel/preset-env", "@babel/preset-react"]    // ������������ �������
                }
            },
            {
                test: /\.(scss)$/,
                use: [
                    {
                        // Adds CSS to the DOM by injecting a `<style>` tag
                        loader: 'style-loader'
                    },
                    {
                        // Interprets `@import` and `url()` like `import/require()` and will resolve them
                        loader: 'css-loader'
                    },
                    {
                        // Loader for webpack to process CSS with PostCSS
                        loader: 'postcss-loader',
                        options: {
                            postcssOptions: {
                                plugins: () => [
                                    autoprefixer
                                ]
                            }
                        }
                    },
                    {
                        // Loads a SASS/SCSS file and compiles it to CSS
                        loader: 'sass-loader'
                    }
                ]
            }
        ]
    }
}