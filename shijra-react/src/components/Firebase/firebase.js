import app from 'firebase/app';
import 'firebase/auth';
import 'firebase/database';

const firebaseConfig = {
    apiKey: "AIzaSyCnouYX-HIg_KJN3xC0XcratnHXPrL-a9o",
    authDomain: "hashmi-shijra.firebaseapp.com",
    databaseURL: "https://hashmi-shijra.firebaseio.com",
    projectId: "hashmi-shijra",
    storageBucket: "hashmi-shijra.appspot.com",
    messagingSenderId: "221260034868",
    appId: "1:221260034868:web:034105ce838ed68c1fab61",
    measurementId: "G-JZ6TDEEPXG"
};


class Firebase {
    constructor() {
        app.initializeApp(firebaseConfig);
        this.auth = app.auth();
        this.db = app.database();
    }

    doSignInWithEmailAndPassword = (email, password) =>
        this.auth.signInWithEmailAndPassword(email, password);

    doSignOut = () => this.auth.signOut();

    persons = () => this.db.ref('person');

    person = (id) => this.db.ref(`person/${id}`);

    getAllMale = () => this.db.ref('person').orderByChild('gender').equalTo(1);

    searchPerson(text) {
        // console.log(text);
        return this.db.ref('person').orderByChild('name').startAt(text).endAt(text + "\uf8ff");
    }

    addPerson(name, urduName, gender, fatherId, father) {
        return this.db.ref(`person`).push({
            name: name,
            urduName: urduName,
            gender: gender,
            father: { [fatherId]: father }
        });
    }

    addChild(key, name, urduName, gender, fatherId) {
        return this.db.ref(`person/${fatherId}/children/${key}`).set({
            name: name,
            urduName: urduName,
            gender: gender
        });
    }

    updatePerson(name, urduName, gender, personId) {
        return this.db.ref(`person/${personId}`).update({
            name: name,
            urduName: urduName,
            gender: gender
        });
    }

    updateSelfAsChild(name, urduName, gender, personId, fatherId) {
        return this.db.ref(`person/${fatherId}/children/${personId}`).update({
            name: name,
            urduName: urduName,
            gender: gender
        });
    }

    updateSelfAsFather(name, urduName, gender, childrenIds, fatherId) {

        var updatedData = {
            name: name,
            urduName: urduName,
            gender: gender
        };

        var updates = {};
        childrenIds.map((childId) => {
            updates[`/person/${childId}/father/${fatherId}`] = updatedData;
            return true;
        });

        console.log(updates);
        return this.db.ref().update(updates);
    }

    deletePerson(personId) {
        return this.db.ref(`person/${personId}`).set(null);
    }

    deleteSelfAsChild(personId, fatherId) {
        return this.db.ref(`person/${fatherId}/children/${personId}`).set(null);
    }



}

export default Firebase;