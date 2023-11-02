import React, {useState} from "react";
import axios from "axios";

const Generate = () => {

    const [amount, setAmount] = useState(0);

    const generateClick = async () => {
        window.location = `/api/people/generate?amount=${amount}`
    }

    return(
        <div className="container" style={{marginTop: 60}}>
            <div className="d-flex vh-100" style={{marginTop: -70}}>
                <div className="d-flex w-100 justify-content-center align-self-center">
                    <div className="row" >
                        <input type="text" className="form-control-lg" placeholder="Amount" value={amount} name="amount" onChange={e => setAmount(e.target.value)}/>
                    </div>
                    <div className="row">
                        <div className="col-md-4 offset-md-2">
                            <button className="btn btn-primary btn-lg" onClick={generateClick}>Generate</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Generate;