module.exports = {
    mode: 'development',
    devServer: {
        historyApiFallback: true
    },
    externals: {
        config: JSON.stringify({
            apiUrl: 'https://localhost:5001' //check
        })
    }
}