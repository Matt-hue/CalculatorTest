document.getElementById("sendButton").addEventListener("click", function (event) {

    var operationType = document.querySelector('input[name="operationType"]:checked').value;

    let firstOperand = parseInt(document.getElementById("first-operand").value);
    let secondOperand = parseInt(document.getElementById("second-operand").value);

    let baseUrl = "https://localhost:44308/api/calculator/";

    switch (operationType) {
        case "Add":
            baseUrl += 'add';
            break;
        case "Subtract":
            baseUrl += 'subtract';
            break;
        case "Multiply":
            baseUrl += 'multiply';
            break;
        case "Divide":
            baseUrl += 'divide';
            break;
        default:
    }

    let url = new URL(baseUrl);
    url.search = new URLSearchParams({ first: firstOperand, second: secondOperand });

    async function makeRequest(url) {

        let response = await fetch(url);

        if (response.ok) {
            let json = await response.json();
            console.log(json);
            document.getElementById("answer").textContent = json;
            result = json;
        } else {
            alert("HTTP-Error: " + response.status);
        }
    }
    makeRequest(url);

    event.preventDefault();
});
