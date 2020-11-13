import React, { Component } from 'react';
import { withFirebase } from '../Firebase';
import './Home.css';

class HomeComponent extends Component {
    render() {
        return <div className="landing">
            <div className="heading1" >شجرہ و نسب نامہ</div>
            <div className="heading2" >ہاشمی / قریشی - بنارس</div>
            <div>
                <div className="nameContainer">
                    <label className="name az">از</label>
                    <br />
                    <label className="name">ابوریحان ہاشمی</label>
                    <br />
                    <label className="name">کاشف عالم ہاشمی</label>
                    <br />
                    <label className="name">انیق ہاشمی</label>
                </div>
                <div className="tree">
                    <img alt="Tree" width="500px" src='./shijra-tree.png'></img>
                </div>
            </div>

        </div>
    }
}

const HomePage = withFirebase(HomeComponent);

const Home = () => (
    <div>
        {/* <h1>Landing</h1> */}
        <HomePage />
    </div>
);

export default Home;